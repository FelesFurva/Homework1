using Microsoft.AspNetCore.Mvc;
using Homework1.Models;

namespace Homework1.Controllers
{
    public class CategoriesController : Controller
    {
        List<CategoriesmModel> categoriesmModel;

        public CategoriesController()
        {
            categoriesmModel = new List<CategoriesmModel>
            {
                new CategoriesmModel
                {
                    CategoryId = 1,
                    CategoryName = "Veggitables"
                },
                new CategoriesmModel
                {
                    CategoryId = 2,
                    CategoryName = "Fruit"
                },
                new CategoriesmModel
                {
                    CategoryId = 3,
                    CategoryName = "Drinks"
                }
            };
        }

        public IActionResult Categories()
        {
            return View(categoriesmModel);
        }
    }
}
