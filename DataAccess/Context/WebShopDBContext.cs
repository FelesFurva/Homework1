using DataAccess.Context.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class WebShopDBContext : DbContext
    {
        public WebShopDBContext(DbContextOptions<WebShopDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category
                    {
                        CategoryId = 1,
                        CategoryName = "Veggitables"
                    },
                    new Category
                    {
                        CategoryId = 2,
                        CategoryName = "Fruit"
                    },
                    new Category
                    {
                        CategoryId = 3,
                        CategoryName = "Drinks"
                    });

            modelBuilder.Entity<SubCategory>()
                .HasData(
                    new SubCategory
                    {
                        SubCategoryId = 1,
                        CategoryId = 1,
                        SubCategoryName = "Root Vegitables"
                    },
                    new SubCategory
                    {
                        SubCategoryId = 2,
                        CategoryId = 1,
                        SubCategoryName = "Peppers"
                    },
                    new SubCategory
                    {
                        SubCategoryId = 3,
                        CategoryId = 2,
                        SubCategoryName = "Bananas"
                    },
                    new SubCategory
                    {
                        SubCategoryId = 4,
                        CategoryId = 2,
                        SubCategoryName = "Exotic Fruits"
                    },
                    new SubCategory
                    {
                        SubCategoryId = 5,
                        CategoryId = 3,
                        SubCategoryName = "Fizzie Drinks"

                    });

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        ProductId = 1,
                        Name = "Banana",
                        Description = "They are yellow",
                        Price = 1.59,
                        SubCategoryID = 3,
                        Location = "row 6"
                    },
                    new Product
                    {
                        ProductId = 2,
                        Name = "Kiwi",
                        Description = "They are green",
                        Price = 0.59,
                        SubCategoryID = 4,
                        Location = "row 6"
                    },
                    new Product
                    {
                        ProductId = 3,
                        Name = "Cake",
                        Description = "Shh! We know ;)",
                        Price = 10.00,
                        SubCategoryID = 4,
                        Location = "row 6"
                    },
                    new Product
                    {
                        ProductId = 4,
                        Name = "Potatoe",
                        Description = "Life!",
                        Price = 0.49,
                        SubCategoryID = 1,
                        Location = "row 4"
                    },
                    new Product
                    {
                        ProductId = 5,
                        Name = "Paprika",
                        Description = "It's red",
                        Price = 1.50,
                        SubCategoryID = 2,
                        Location = "row 3"
                    },
                    new Product
                    {
                        ProductId = 6,
                        Name = "Pepsi",
                        Description = "No sugar",
                        Price = 0.79,
                        SubCategoryID = 5,
                        Location = "row 2"
                    });
        }
    }
}
