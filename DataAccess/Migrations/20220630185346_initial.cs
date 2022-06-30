using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Veggitables" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Fruit" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Drinks" });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "SubCategoryId", "CategoryId", "SubCategoryName" },
                values: new object[,]
                {
                    { 1, 1, "Root Vegitables" },
                    { 2, 1, "Peppers" },
                    { 3, 2, "Bananas" },
                    { 4, 2, "Exotic Fruits" },
                    { 5, 3, "Fizzie Drinks" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Location", "Name", "Price", "SubCategoryID" },
                values: new object[,]
                {
                    { 1, "They are yellow", "row 6", "Banana", 1.5900000000000001, 3 },
                    { 2, "They are green", "row 6", "Kiwi", 0.58999999999999997, 4 },
                    { 3, "Shh! We know ;)", "row 6", "Cake", 10.0, 4 },
                    { 4, "Life!", "row 4", "Potatoe", 0.48999999999999999, 1 },
                    { 5, "It's red", "row 3", "Paprika", 1.5, 2 },
                    { 6, "No sugar", "row 2", "Pepsi", 0.79000000000000004, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryID",
                table: "Products",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
