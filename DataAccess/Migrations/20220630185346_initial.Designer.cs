﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(WebShopDBContext))]
    [Migration("20220630185346_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

            modelBuilder.Entity("DataAccess.Context.Entity.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

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
                            Location = "row 6",
                            Name = "Banana",
                            Price = 1.5900000000000001,
                            SubCategoryID = 3
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "They are green",
                            Location = "row 6",
                            Name = "Kiwi",
                            Price = 0.58999999999999997,
                            SubCategoryID = 4
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Shh! We know ;)",
                            Location = "row 6",
                            Name = "Cake",
                            Price = 10.0,
                            SubCategoryID = 4
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "Life!",
                            Location = "row 4",
                            Name = "Potatoe",
                            Price = 0.48999999999999999,
                            SubCategoryID = 1
                        },
                        new
                        {
                            ProductId = 5,
                            Description = "It's red",
                            Location = "row 3",
                            Name = "Paprika",
                            Price = 1.5,
                            SubCategoryID = 2
                        },
                        new
                        {
                            ProductId = 6,
                            Description = "No sugar",
                            Location = "row 2",
                            Name = "Pepsi",
                            Price = 0.79000000000000004,
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

            modelBuilder.Entity("DataAccess.Context.Entity.Category", b =>
                {
                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("DataAccess.Context.Entity.SubCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}