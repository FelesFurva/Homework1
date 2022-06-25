using OnlineStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        private DatabaseManager databaseManager;

        public ProductsController(DatabaseManager databaseManager)
        {
            this.databaseManager = databaseManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var product = new ProductsModel();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    databaseManager.AddProducttoDB(product);
                    return RedirectToAction("Products");
                }
                return View(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Products()
        {
            return View(databaseManager.GetProducts());
        }

        public IActionResult FindById(int specific)
        {
            var model = databaseManager.GetProductsByID(specific);
            if(model == null)
            {
                return RedirectToAction("Products");
            }
            return View(model);
        }
    }
}
