using OnlineStore.Models;
using OnlineStore.Extention;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreServices.Managers;

namespace OnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ISubCategoryManager _subCategoryManager;
        

        public ProductsController(IProductManager productManager, ISubCategoryManager subCategoryManager)
        {
            _productManager = productManager;
            _subCategoryManager = subCategoryManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var product = new ProductViewModel();
            product.SubCategories = _subCategoryManager.GetSubCategories().ToModel();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateModel product)
        {
            var viewModel = new ProductViewModel();
            viewModel.SubCategories = _subCategoryManager.GetSubCategories().ToModel();

            ModelState.Remove(nameof(product.Image));
            ModelState.Remove(nameof(product.Filepath));
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(product.Image.FileName);
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;

                string saveFolderName = "Photo";
    
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", saveFolderName, uniqueFileName);
                var filePathForDB = $"~/{saveFolderName}/{uniqueFileName}";

                product.Image.CopyTo(new FileStream(filepath, FileMode.Create));

                var newProduct = new ProductsModel
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    SubCategoryID = product.SubCategoryID,
                    Location = product.Location,
                    Filepath = filePathForDB,
                };
                
                _productManager.AddProducttoDB(newProduct.ToEntity());
                return RedirectToAction("Products");
            }
            return View(viewModel);
        }

        public IActionResult Products()
        {
            var products = _productManager.GetProducts().ToModel();
            return View(products);
        }

        public IActionResult FindById(int specific)
        {
            var model = _productManager.GetProductsByID(specific);
            var productModel = model.ToModel();
            if (productModel == null)
            {
                return RedirectToAction("Products");
            }
            return View(productModel);
        }
    }
}
