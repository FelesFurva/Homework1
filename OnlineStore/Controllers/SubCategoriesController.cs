using DataAccess.Context.Entity;
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
            var subCategories = _subCategoryManager.GetSubCategories();
            var subCategoryList = subCategories.Select(subCategory => subCategory.ToSubCategoryModel());
            return View(subCategoryList);
        }

        [HttpGet]
        public IActionResult CreateSubCategory()
        {
            var subCategory = new SubCategoryViewModel();
            subCategory.Categories = _categoryManager.GetCategories().Select(category => category.ToModel());
            return View(subCategory);
        }

        [HttpPost]
        public IActionResult CreateSubCategory(SubCategoryCreateModel subCategory)
        {
                if (ModelState.IsValid)
                {
                    var newSubCategory = new SubCategory
                    {
                        SubCategoryName = subCategory.SubCategoryName,
                        CategoryId = subCategory.CategoryId
                    };
                    _subCategoryManager.AddSubCategoryDB(newSubCategory);
                    return RedirectToAction("SubCategories");
                }
                return BadRequest("Invalid SubCatefory Model");
        }

        public IActionResult FindBySubCategory(int specific)
        {
            var productsbyCategory = _subCategoryManager.GetItemsBySubCategoryId(specific).ToSubCategoryModel();
            return View(productsbyCategory);
        }
    }
}
