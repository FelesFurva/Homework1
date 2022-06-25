using OnlineStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using OnlineStoreServices.Managers;
using DataAccess.Context.Entity;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {

        private CategoryManager categoryManager;
        private ProductManager productManager;

        public HomeController(CategoryManager categoryManager, ILogger<HomeController> logger, ProductManager productManager)
        {
            this.categoryManager = categoryManager;
            _logger = logger;
            this.productManager = productManager;
        }

        private readonly ILogger<HomeController> _logger;

        public IActionResult Index(int? selectedCategory = 1)
        { 
            IEnumerable<Category> categories = categoryManager.GetCategories();
            IEnumerable<Product> products = productManager.GetProductsbyCategory(selectedCategory);

            var homeView = new HomeViewModel
            {
                CategoriesList = categories.Select(categories => new CategoryModel {
                    CategoryId = categories.CategoryId,
                    CategoryName = categories.CategoryName,
                }),

                Products = products.Select(products => new ProductsModel { 
                    ProductId = products.ProductId,
                    Price = products.Price,
                    Name = products.Name,
                    Description = products.Description,
                    Location = products.Location,
                    CategoryID = products.CategoryID
                }),
            };

            return View(homeView); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}