using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class ImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Url" },
                values: new object[,]
                {
                    { 1, "https://my-jsonserver.typicode.com/ck-pacificdev/tech-test/images/1" },
                    { 2, "https://my-jsonserver.typicode.com/ck-pacificdev/tech-test/images/2" },
                    { 3, "https://my-jsonserver.typicode.com/ck-pacificdev/tech-test/images/3" },
                    { 4, "https://my-jsonserver.typicode.com/ck-pacificdev/tech-test/images/4" },
                    { 5, "https://my-jsonserver.typicode.com/ck-pacificdev/tech-test/images/5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
