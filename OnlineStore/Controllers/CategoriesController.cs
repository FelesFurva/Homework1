using OnlineStore.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreServices.Managers;

namespace OnlineStore.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryManager categoryManager;

        public CategoriesController(CategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        public IActionResult Categories()
        {
            var categories = categoryManager.GetCategories();
            var categoriesList = categories.Select(category => new CategoryModel{ 
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            });
            return View(categoriesList);
        }

        public IActionResult FindByCategory(int specific)
        {
            var productsbyCategory = categoryManager.GetItemsByCategorybyId(specific);
            var productsModelsbyCategory = new CategoryModel { 
            CategoryId = productsbyCategory.CategoryId,
            Products = productsbyCategory.Products.Select(product => new ProductsModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Location = product.Location,
                Description = product.Description,
                CategoryID = product.CategoryID,
                Price = product.Price,
            })
            };
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
                    categoryManager.AddCategoryDB(category.CategoryName);
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
