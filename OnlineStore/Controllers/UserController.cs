using Microsoft.AspNetCore.Mvc;
using OnlineStore.Extention;
using OnlineStore.Models;
using OnlineStoreServices.Managers;

namespace OnlineStore.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
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
                if (_userManager.CheckIfEmailIsAvailable(user.Email))
                {
                    ModelState.AddModelError("email", $"E-mail: {user.Email} is taken");
                    return View();
                }
                _userManager.AddUserToDB(user.ToEntity());
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
