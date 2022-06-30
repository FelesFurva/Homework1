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
            var categories = _categoryManager.GetCategories();
            var categoriesList = categories.Select(category => category.ToModel());
            return View(categoriesList);
        }

        public IActionResult FindByCategory(int specific)
        {
            var subCategoriesbyCategory = _categoryManager.GetSubCategoryByCategoryId(specific).ToModel();
            return View(subCategoriesbyCategory);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            var category = new CategoryModel();
            return View(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryCreateModel category)
        {
                if (ModelState.IsValid)
                {
                    _categoryManager.AddCategoryDB(category.CategoryName);
                    return RedirectToAction("Categories");
                }
                return View(category);
        }
    }
}
