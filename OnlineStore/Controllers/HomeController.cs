﻿using OnlineStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using OnlineStoreServices.Managers;
using DataAccess.Context.Entity;
using OnlineStore.Extention;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoryManager _categoryManager;
        private IProductManager _productManager;
        private readonly ISubCategoryManager _subCategoryManager;

        public HomeController(ICategoryManager categoryManager, ILogger<HomeController> logger, IProductManager productManager, ISubCategoryManager subCategoryManager)
        {
            _categoryManager = categoryManager;
            _logger = logger;
            _productManager = productManager;
            _subCategoryManager = subCategoryManager;
        }

        private readonly ILogger<HomeController> _logger;

        public IActionResult Index(int selectedSubCategory = 1)
        { 
            IEnumerable<Category> categories = _categoryManager.GetCategoriesWithSubs();
            IEnumerable<Product> products = _productManager.GetProductsbySubCategory(selectedSubCategory);
            //IEnumerable<SubCategory> subCategories = _subCategoryManager.GetSubCategoriesbyCategory(selectedCategory);

            var homeView = new HomeViewModel
            {
                CategoriesList = categories.Select(categories => categories.ToModel()),

                Products = products.Select(products => products.ToProductModel()),
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