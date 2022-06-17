﻿// <auto-generated />
using Homework1.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Homework1.Migrations
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

            modelBuilder.Entity("Homework1.Context.Entity.Category", b =>
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

            modelBuilder.Entity("Homework1.Context.Entity.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

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

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryID = 2,
                            Description = "They are yellow",
                            Location = "row 6",
                            Name = "Banana",
                            Price = 1.5900000000000001
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryID = 2,
                            Description = "They are green",
                            Location = "row 6",
                            Name = "Kiwi",
                            Price = 0.58999999999999997
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryID = 2,
                            Description = "Shh! We know ;)",
                            Location = "row 6",
                            Name = "Cake",
                            Price = 10.0
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryID = 1,
                            Description = "Life!",
                            Location = "row 4",
                            Name = "Potatoe",
                            Price = 0.48999999999999999
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryID = 1,
                            Description = "It's red",
                            Location = "row 3",
                            Name = "Paprika",
                            Price = 1.5
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryID = 3,
                            Description = "No sugar",
                            Location = "row 2",
                            Name = "Pepsi",
                            Price = 0.79000000000000004
                        });
                });

            modelBuilder.Entity("Homework1.Context.Entity.Product", b =>
                {
                    b.HasOne("Homework1.Context.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Homework1.Context.Entity.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
