using DataAccess.Context.Entity;
using NUnit.Framework.Constraints;
using OnlineStore.Extention;
using OnlineStore.Models;

namespace Homeork1.Tests
{
    internal class CartMapperTest
    {
        private CartMapper _cartMapper;

        [SetUp]
        public void Setup()
        {
            _cartMapper = new CartMapper();
        }

        [Test]
        public void  ToModel_CartIsValid_ShouldSucceed()
        {
            //Arrange
            Cart cart = new Cart
            {
                CartId = 1,
            };

            //Act
            var result = _cartMapper.ToModel(cart);
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(cart.CartId, result.CartId);
            Assert.AreEqual(result.Items, new List<CartItem>()); ;
            Assert.That(result.Items, Is.EqualTo(new List<CartItemModel>()));
            CollectionAssert.AreEqual(result.Items, new List<CartItemModel>());
        }
        [Test]
        public void ToModel_CartIsNull_ShouldThrowNullReferenceException()
        {
            //Arrange

            //Act
           ActualValueDelegate<object> testDelegate = () => _cartMapper.ToModel((Cart)null);
            //Assert
            Assert.That(testDelegate, Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void ToModel_CartIsWithoutId_ShouldSucceed()
        {
            //Arrange
            Cart cart = new Cart();
            //Act
            var result = _cartMapper.ToModel(cart);
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(cart.CartId, result.CartId);
            CollectionAssert.AreEqual(result.Items, new List<CartItemModel>());
        }
    }
}
