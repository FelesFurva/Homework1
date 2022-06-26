using OnlineStore.Models;
using OnlineStore.Extention;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreServices.Managers;
using DataAccess.Context.Entity;

namespace OnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        private ProductManager productManager;
        private CategoryManager categoryManager;

        public ProductsController(ProductManager productManager, CategoryManager categoryManager)
        {
            this.productManager = productManager;
            this.categoryManager = categoryManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var product = new ProductCreateViewModel();
            product.Categories = categoryManager.GetCategories().Select(category => category.ToModel());
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
            var products = productManager.GetProducts();
            var productList = products.Select(product => product.ToProductModel());
                        
            return View(productList);
        }

        public IActionResult FindById(int specific)
        {
            var model = productManager.GetProductsByID(specific);
            var productModel = model.ToProductModel();
            if (productModel == null)
            {
                return RedirectToAction("Products");
            }
            return View(productModel);
        }
    }
}
