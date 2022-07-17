using Microsoft.AspNetCore.Mvc;
using OnlineStore.Extention;
using OnlineStore.Models;
using OnlineStoreServices.Managers;

namespace OnlineStore.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly ICartManager _cartManager;

        public UserController(IUserManager userManager, ICartManager cartManager)
        {
            _userManager = userManager;
            _cartManager = cartManager;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            var user = new UserCreateModel();
            return View(user);
        }
        [HttpPost]
        public IActionResult CreateUser(UserCreateModel user)
        {
            if (user.Password != user.RepeatPassword)
            {
                ModelState.AddModelError("[password]", "Password and repeat don't match");
            }

            if (ModelState.IsValid)
            {
                if (_userManager.CheckIfEmailIsTaken(user.Email))
                {
                    ModelState.AddModelError("email", $"E-mail: {user.Email} is taken");
                    return View();
                }
                var userForDb = user.ToEntity();
                _userManager.AddUserToDB(userForDb);
                _cartManager.AddCartToDB(userForDb.UserId);
                return RedirectToAction("LoginUser");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult LoginUser()
        {
            var user = new UserLoginModel();
            return View(user);
        }
        [HttpPost]
        public IActionResult LoginUser(UserLoginModel userModel)
        {
            var user = _userManager.GetUser(userModel.Email, userModel.Password);
            
            if (user is null)
            {
                ModelState.AddModelError("user", "email or password incorrect");
                return View(userModel);
            }
            else
            {
                HttpContext.Session.SetSession(user);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogoutUser()
        {
            HttpContext.Session.Clear();
            var user = new UserLoginModel();
            return RedirectToAction("LoginUser");
        }
    }
}
