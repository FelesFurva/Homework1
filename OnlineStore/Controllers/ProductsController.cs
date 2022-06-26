using OnlineStore.Models;
using OnlineStore.Extention;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreServices.Managers;
using DataAccess.Context.Entity;

namespace OnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        private IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;

        public ProductsController(IProductManager productManager, ICategoryManager categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var product = new ProductCreateViewModel();
            product.Categories = _categoryManager.GetCategories().Select(category => category.ToModel());
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
                    _productManager.AddProducttoDB(newProduct);
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
            var products = _productManager.GetProducts();
            var productList = products.Select(product => product.ToProductModel());
                        
            return View(productList);
        }

        public IActionResult FindById(int specific)
        {
            var model = _productManager.GetProductsByID(specific);
            var productModel = model.ToProductModel();
            if (productModel == null)
            {
                return RedirectToAction("Products");
            }
            return View(productModel);
        }
    }
}
