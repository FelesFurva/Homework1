using DataAccess.Context;
using DataAccess.Context.Entity;
using Microsoft.EntityFrameworkCore;
using Moq;
using OnlineStoreServices.Managers;
using Crypt = BCrypt.Net.BCrypt;

namespace OnlineStoreServices.Test.Managers
{
    internal class UserManagerTest
    {
        private Mock<IWebShop> _dbContext;
        private IUserManager _userManager;

        [SetUp]
        public void SetUp()
        {
            _dbContext = new Mock<IWebShop>();
            _userManager = new UserManager(_dbContext.Object);

            var data = new List<User>
            {
                new User { Email = "test1@test1.com", Password = Crypt.HashPassword("test1") },
                new User { Email = "test@test.com" , Password = Crypt.HashPassword("test") },
                new User { Email = "test2@test2.com", Password = Crypt.HashPassword("test2") },
            }.AsQueryable();

            var UserSet = new Mock<DbSet<User>>();
            UserSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            UserSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            UserSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            UserSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            _dbContext.Setup(db => db.User).Returns(UserSet.Object);
        }

        [Test]
        public void GetUser_UserIsValid_ShouldReturnUser()
        {
            // Act
            string Email = "test@test.com";
            string Password = "test";
            string badMail = "not@there.com";
            string badPassword = "forSure";
            var expected = new User
            {
                Email = Email,
                Password = Crypt.HashPassword(Password)
            };

            // Arrange
            var actual = _userManager.GetUser(Email, Password);
            var notActual = _userManager.GetUser(badMail, badPassword);
            var wrongMail = _userManager.GetUser(badMail, Password);
            var wrongPassword = _userManager.GetUser(Email, badPassword);

            // Asssert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.That(Crypt.Verify(Password, actual.Password));
            Assert.IsNull(notActual);
            Assert.IsNull(wrongMail);
            Assert.IsNull(wrongPassword);
        }

        [Test]
        public void CheckEmail_IsEmailAvailable()
        {
            string Email = "free@test.com";
            string Email2 = "test@test.com";

            var actual = _userManager.CheckIfEmailIsTaken(Email);
            var actual2 = _userManager.CheckIfEmailIsTaken(Email2);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual);
            Assert.IsTrue(actual2);
        }

        [Test]
        public void AddUserToDB_ShouldcCreateUser()
        {
            string Email = "test@mail.com";
            string Password = "testPassword";
            string Name = "testName";

            var newUser = new User
            {
                Email = Email,
                Password = Password,
                Name = Name
            };

            var newUser2 = new User
            {
                Email = "aaa",
                Password = "aaa",
                Name = "aaa"
            };
            
            _dbContext.Setup(urm => urm.User.Add(newUser)).Verifiable();
            _dbContext.Setup(urm => urm.SaveChanges()).Verifiable();
            _userManager.AddUserToDB(newUser);
            _dbContext.Verify(context => context.User.Add(newUser), Times.Once);
            _dbContext.Verify(context => context.User.Add(newUser2), Times.Never);
            _dbContext.Verify(context => context.SaveChanges(), Times.Once);

            var exception = Assert.Throws<ArgumentNullException>(() => _userManager.AddUserToDB((User)null));
            Assert.That(exception.GetType() == typeof(ArgumentNullException));
            Assert.That(exception.ParamName == "newUser");

        }
    } 
}

