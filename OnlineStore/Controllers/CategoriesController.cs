using OnlineStore.Models;
using OnlineStore.Extention;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreServices.Managers;

namespace OnlineStore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public CategoriesController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IActionResult Categories()
        {
            if (!HttpContext.Session.IsUserAdmin())
            {
                return RedirectToAction("LoginUser", "User");
            }
            var categories = _categoryManager.GetCategories().ToModel();
            return View(categories);
        }

        public IActionResult FindByCategory(int specific)
        {
            if(!HttpContext.Session.IsUserAdmin())
            {
                return RedirectToAction("LoginUser", "User");
            }
            var subCategoriesbyCategory = _categoryManager.GetSubCategoryByCategoryId(specific).ToModel();
            return View(subCategoriesbyCategory);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            if (!HttpContext.Session.IsUserAdmin())
            {
                return RedirectToAction("LoginUser", "User");
            }
            var category = new CategoryModel();
            return View(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryCreateModel category)
        {
            if (!HttpContext.Session.IsUserAdmin())
            {
                return RedirectToAction("LoginUser", "User");
            }
            if (ModelState.IsValid)
            {
                _categoryManager.AddCategoryDB(category.CategoryName);
                return RedirectToAction("Categories");
            }
            return View(category);
        }
    }
}
