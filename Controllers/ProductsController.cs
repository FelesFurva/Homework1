using Homework1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.Controllers
{
    public class ProductsController : Controller
    {
        List<ProductsModel> productsModels;

        public ProductsController()
        {
            productsModels = new List<ProductsModel>
            {
                new ProductsModel
                {
                    Id = 1,
                    Name = "Banana",
                    Description = "They are yellow",
                    Price = 1.59,
                    CategoryID = 2
                },
                new ProductsModel
                {
                    Id=2,
                    Name = "Kiwi",
                    Description = "They are green",
                    Price = 0.59,
                    CategoryID = 2
                },
                new ProductsModel
                {
                    Id=3,
                    Name = "Cake",
                    Description = "Shh! We know ;)",
                    Price = 10.00,
                    CategoryID = 2
                },
                new ProductsModel
                {
                    Id=4,
                    Name = "Potatoe",
                    Description = "Life!",
                    Price = 0.49,
                    CategoryID = 1
                },
                new ProductsModel
                {
                    Id=5,
                    Name = "Paprika",
                    Description = "It's red",
                    Price = 1.50,
                    CategoryID = 1
                },
                new ProductsModel
                {
                    Id=6,
                    Name = "Pepsi",
                    Description = "No sugar",
                    Price = 0.79,
                    CategoryID = 3
                }

            };
         }


        public IActionResult Products()
        {
            return View(productsModels);
        }

        public IActionResult FindById(int specific)
        {
            ProductsModel model;
            if (productsModels.Exists(product => product.Id == specific))
            {
                model = productsModels.Find(product => product.Id == specific);
            }
            else
            {
                return RedirectToAction("Products");
            }

            return View(model);
        }
        
        public IActionResult Find(int specific)
        {
            List<ProductsModel> productsModelsbyCategory;
            productsModelsbyCategory = new List<ProductsModel>();

            foreach (var product in productsModels)
            {
                if (product.CategoryID == specific)
                {
                    productsModelsbyCategory.Add(product);
                }
            }

            return View(productsModelsbyCategory);
        }
    }
}
