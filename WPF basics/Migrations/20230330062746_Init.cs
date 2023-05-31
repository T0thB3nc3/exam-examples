using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Szinkronstudio.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoryModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Versenyzok",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Length = table.Column<int>(type: "int", nullable: false),
                    DubProducer = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AnnouncedInHungary = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versenyzok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versenyzok_CategoryModel_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CategoryModel",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Romantic" },
                    { 2, "Sci-Fi" },
                    { 3, "Action" },
                    { 4, "Comedy" },
                    { 5, "Documentary" },
                    { 6, "Cartoon" }
                });

            migrationBuilder.InsertData(
                table: "Versenyzok",
                columns: new[] { "Id", "AnnouncedInHungary", "CategoryId", "DubProducer", "Length", "Title" },
                values: new object[,]
                {
                    { "1920/915", null, 1, "Adolf Stalin", 135, "My Fellow Jonathan" },
                    { "1972/521", null, 2, "Bull Shark Testosterone", 79, "Space Amoeba" },
                    { "1998/315", null, 5, "Ben Dover", 234, "Nature of Harambe" },
                    { "2004/032", null, 3, "Carl Johnson", 96, "Gangs of the Grove Street" },
                    { "2020/14", null, 6, "US Government", 71, "Mickey and the Nazis" },
                    { "2020/15", null, 4, "John Doe", 126, "Johnny and the Two A**holes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryModel_Name",
                table: "CategoryModel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Versenyzok_CategoryId",
                table: "Versenyzok",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Versenyzok");

            migrationBuilder.DropTable(
                name: "CategoryModel");
        }
    }
}
