using OnlineStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {

        private DatabaseManager databaseManager;

        public HomeController(DatabaseManager databaseManager, ILogger<HomeController> logger)
        {
            this.databaseManager = databaseManager;
            _logger = logger;
        }

        private readonly ILogger<HomeController> _logger;

        public IActionResult Index(int? selectedCategory = 1)
        {
            IEnumerable<CategoryModel> categories = databaseManager.GetCategories();
            IEnumerable<ProductsModel> products = databaseManager.GetProductsbyCategory(selectedCategory);

            var homeView = new HomeViewModel
            {
                CategoriesList = categories,
                Products = products,
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