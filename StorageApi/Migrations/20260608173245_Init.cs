using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StorageApi2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shelf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Count", "Description", "Name", "Price", "Shelf" },
                values: new object[,]
                {
<<<<<<<< HEAD:StorageApi/Migrations/20260608173245_Init.cs
                    { 1, "Tools", 5, "Wooden handle.", "Hammer", 10m, "A1" },
                    { 2, "Tools", 10, "The one with the flat head.", "Screwdriver", 5m, "A2" },
                    { 3, "Tools", 7, "The one with the adjustable jaw.", "Wrench", 15m, "A3" },
                    { 4, "Tools", 10, "The one with the thoots.", "Saw", 5m, "A2" }
========
                    { 1, "Tools", 5, "Wooden handle.", "Hammer", 10, "A1" },
                    { 2, "Tools", 10, "The one with the flat head.", "Screwdriver", 5, "A2" },
                    { 3, "Tools", 7, "The one with the adjustable jaw.", "Wrench", 15, "A3" },
                    { 4, "Tools", 10, "The one with the thoots.", "Saw", 5, "A2" }
>>>>>>>> 2ef3b6492edbc0316b8b661e1ce9c87a199f0f49:StorageApi/Migrations/20260608154633_Init.cs
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
