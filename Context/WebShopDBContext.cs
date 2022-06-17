using Homework1.Context.Entity;
using Microsoft.EntityFrameworkCore;

namespace Homework1.Context
{
    public class WebShopDBContext : DbContext
    {
        public WebShopDBContext(DbContextOptions<WebShopDBContext> options): base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
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

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        ProductId = 1,
                        Name = "Banana",
                        Description = "They are yellow",
                        Price = 1.59,
                        CategoryID = 2,
                        Location = "row 6"
                    },
                    new Product
                    {
                        ProductId = 2,
                        Name = "Kiwi",
                        Description = "They are green",
                        Price = 0.59,
                        CategoryID = 2,
                        Location = "row 6"
                    },
                    new Product
                    {
                        ProductId = 3,
                        Name = "Cake",
                        Description = "Shh! We know ;)",
                        Price = 10.00,
                        CategoryID = 2,
                        Location = "row 6"
                    },
                    new Product
                    {
                        ProductId = 4,
                        Name = "Potatoe",
                        Description = "Life!",
                        Price = 0.49,
                        CategoryID = 1,
                        Location = "row 4"
                    },
                    new Product
                    {
                        ProductId = 5,
                        Name = "Paprika",
                        Description = "It's red",
                        Price = 1.50,
                        CategoryID = 1,
                        Location = "row 3"
                    },
                    new Product
                    {
                        ProductId = 6,
                        Name = "Pepsi",
                        Description = "No sugar",
                        Price = 0.79,
                        CategoryID = 3,
                        Location = "row 2"
                    });
        }
    }
}
