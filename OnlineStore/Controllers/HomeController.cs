using OnlineStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using OnlineStoreServices.Managers;
using OnlineStore.Extention;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoryManager _categoryManager;
        private readonly IProductManager _productManager;

        public HomeController(ICategoryManager categoryManager,
                              ILogger<HomeController> logger,
                              IProductManager productManager)
        {
            _categoryManager = categoryManager;
            _logger = logger;
            _productManager = productManager;
        }

        private readonly ILogger<HomeController> _logger;

        public IActionResult Index(int selectedSubCategory = 1)
        { 
            IEnumerable<CategoryModel> categories = _categoryManager.GetCategoriesWithSubs().ToModel();
            IEnumerable<ProductsModel> products = _productManager.GetProductsbySubCategory(selectedSubCategory).ToModel();

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