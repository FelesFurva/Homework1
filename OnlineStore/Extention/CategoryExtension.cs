﻿using DataAccess.Context.Entity;
using OnlineStore.Models;

namespace OnlineStore.Extention
{
    public static class CategoryExtension
    {
        public static CategoryModel ToModel(this Category category)
        {
            return new CategoryModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Products = category.Products?.Select(product => product.ToProductModel())
            };
        }
    }
}