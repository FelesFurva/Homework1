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
        private readonly ISubCategoryManager _subCategoryManager;

        public ProductsController(IProductManager productManager, ISubCategoryManager subCategoryManager)
        {
            _productManager = productManager;
            _subCategoryManager = subCategoryManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var product = new ProductCreateViewModel();
            product.SubCategories = _subCategoryManager.GetSubCategories().Select(subCategory => subCategory.ToSubCategoryModel());
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateModel product)
        {
            if (ModelState.IsValid)
            {
                var newProduct = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    SubCategoryID = product.SubCategoryID,
                    Location = product.Location
                };
                _productManager.AddProducttoDB(newProduct);
                return RedirectToAction("Products");
            }
            return BadRequest("Invalid Product Model"); ;
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
