using OnlineStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Controllers
{
    public class CategoriesController : Controller
    {
        private DatabaseManager databaseManager;

        public CategoriesController(DatabaseManager databaseManager)
        {
            this.databaseManager = databaseManager;
        }

        public IActionResult Categories()
        {
            var categories = databaseManager.GetCategories();
            return View(categories);
        }

        public IActionResult FindByCategory(int specific)
        {
            var productsModelsbyCategory = databaseManager.GetItemsByCategorybyId(specific);
            return View(productsModelsbyCategory);
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
            try
            {
                if (ModelState.IsValid)
                {
                    databaseManager.AddCategoryDB(category.CategoryName);
                    return RedirectToAction("Categories");
                }
                return View(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
