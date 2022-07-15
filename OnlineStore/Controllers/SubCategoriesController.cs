using Microsoft.AspNetCore.Mvc;
using OnlineStore.Extention;
using OnlineStore.Models;
using OnlineStoreServices.Managers;

namespace OnlineStore.Controllers
{
    public class SubCategoriesController : Controller
    {
        private readonly ISubCategoryManager _subCategoryManager;
        private readonly ICategoryManager _categoryManager;

        public SubCategoriesController(ISubCategoryManager subCategoryManager, ICategoryManager categoryManager)
        {
            _subCategoryManager = subCategoryManager;
            _categoryManager = categoryManager;
        }

        public IActionResult SubCategories()
        {
            if (!HttpContext.Session.IsUserAdmin())
            {
                return RedirectToAction("LoginUser", "User");
            }
            var subCategories = _subCategoryManager.GetSubCategories().ToModel();
            return View(subCategories);
        }

        [HttpGet]
        public IActionResult CreateSubCategory()
        {
            if (!HttpContext.Session.IsUserAdmin())
            {
                return RedirectToAction("LoginUser", "User");
            }
            var subCategory = new SubCategoryViewModel();
            subCategory.Categories = _categoryManager.GetCategories().ToModel();
            return View(subCategory);
        }

        [HttpPost]
        public IActionResult CreateSubCategory(SubCategoryCreateModel subCategory)
        {
            if (!HttpContext.Session.IsUserAdmin())
            {
                return RedirectToAction("LoginUser", "User");
            }
            var viewModel = new SubCategoryViewModel();
            viewModel.Categories = _categoryManager.GetCategories().ToModel();
            
            if (ModelState.IsValid)
            {
                var newSubCategory = new SubCategoryModel
                {
                    SubCategoryName = subCategory.SubCategoryName,
                    CategoryId = subCategory.CategoryId
                };
                _subCategoryManager.AddSubCategoryDB(newSubCategory.ToEntity());
                return RedirectToAction("SubCategories");
            }
            return View(viewModel);
        }

        public IActionResult FindBySubCategory(int specific)
        {
            if (!HttpContext.Session.IsUserAdmin())
            {
                return RedirectToAction("LoginUser", "User");
            }
            var productsbyCategory = _subCategoryManager.GetItemsBySubCategoryId(specific).ToModel();
            return View(productsbyCategory);
        }
    }
}
