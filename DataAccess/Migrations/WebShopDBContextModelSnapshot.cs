﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(WebShopDBContext))]
    partial class WebShopDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.Context.Entity.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemId"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Veggitables"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Fruit"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Drinks"
                        });
                });

            modelBuilder.Entity("DataAccess.Context.Entity.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OrderTotalSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Filepath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SubCategoryID")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("SubCategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "They are yellow",
                            Filepath = "~/Photo/Banana.jpg",
                            Location = "row 6",
                            Name = "Banana",
                            Price = 1.59m,
                            SubCategoryID = 3
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "They are green",
                            Filepath = "~/Photo/Kiwi.jpg",
                            Location = "row 6",
                            Name = "Kiwi",
                            Price = 0.59m,
                            SubCategoryID = 4
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Shh! We know ;)",
                            Filepath = "~/Photo/Cake.jpg",
                            Location = "row 6",
                            Name = "Cake",
                            Price = 10.00m,
                            SubCategoryID = 4
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "Life!",
                            Filepath = "~/Photo/Potatoe.jpg",
                            Location = "row 4",
                            Name = "Potatoe",
                            Price = 0.49m,
                            SubCategoryID = 1
                        },
                        new
                        {
                            ProductId = 5,
                            Description = "It's red",
                            Filepath = "~/Photo/Paprika.jpg",
                            Location = "row 3",
                            Name = "Paprika",
                            Price = 1.50m,
                            SubCategoryID = 2
                        },
                        new
                        {
                            ProductId = 6,
                            Description = "No sugar",
                            Filepath = "~/Photo/Pepsi.jpg",
                            Location = "row 2",
                            Name = "Pepsi",
                            Price = 0.79m,
                            SubCategoryID = 5
                        });
                });

            modelBuilder.Entity("DataAccess.Context.Entity.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategoryId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SubCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");

                    b.HasData(
                        new
                        {
                            SubCategoryId = 1,
                            CategoryId = 1,
                            SubCategoryName = "Root Vegitables"
                        },
                        new
                        {
                            SubCategoryId = 2,
                            CategoryId = 1,
                            SubCategoryName = "Peppers"
                        },
                        new
                        {
                            SubCategoryId = 3,
                            CategoryId = 2,
                            SubCategoryName = "Bananas"
                        },
                        new
                        {
                            SubCategoryId = 4,
                            CategoryId = 2,
                            SubCategoryName = "Exotic Fruits"
                        },
                        new
                        {
                            SubCategoryId = 5,
                            CategoryId = 3,
                            SubCategoryName = "Fizzie Drinks"
                        });
                });

            modelBuilder.Entity("DataAccess.Context.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.Cart", b =>
                {
                    b.HasOne("DataAccess.Context.Entity.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("DataAccess.Context.Entity.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.CartItem", b =>
                {
                    b.HasOne("DataAccess.Context.Entity.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Context.Entity.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.Order", b =>
                {
                    b.HasOne("DataAccess.Context.Entity.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.OrderItem", b =>
                {
                    b.HasOne("DataAccess.Context.Entity.Order", "Order")
                        .WithMany("OrderedItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Context.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.Product", b =>
                {
                    b.HasOne("DataAccess.Context.Entity.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.SubCategory", b =>
                {
                    b.HasOne("DataAccess.Context.Entity.Category", "Category")
                        .WithMany("SubCategory")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.Category", b =>
                {
                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.Order", b =>
                {
                    b.Navigation("OrderedItems");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.Product", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.SubCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.User", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
