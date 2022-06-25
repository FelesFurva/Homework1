using OnlineStore.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreServices.Managers;
using DataAccess.Context.Entity;

namespace OnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        private ProductManager productManager;

        public ProductsController(ProductManager productManager)
        {
            this.productManager = productManager;
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
                    var newProduct = new Product
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        CategoryID = product.CategoryID,
                        Location = product.Location
                    };
                    productManager.AddProducttoDB(newProduct);
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
            return View(productManager.GetProducts());
        }

        public IActionResult FindById(int specific)
        {
            var model = productManager.GetProductsByID(specific);
            if(model == null)
            {
                return RedirectToAction("Products");
            }
            return View(model);
        }
    }
}
