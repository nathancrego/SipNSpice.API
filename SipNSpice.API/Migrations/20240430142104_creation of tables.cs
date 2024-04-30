using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SipNSpice.API.Migrations
{
    /// <inheritdoc />
    public partial class creationoftables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblsnsbases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblsnsbases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblsnscuisines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainCuisine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCuisine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblsnscuisines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblsnsdrinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblsnsdrinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblsnsrecipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblsnsrecipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseDrink",
                columns: table => new
                {
                    BasesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrinksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseDrink", x => new { x.BasesId, x.DrinksId });
                    table.ForeignKey(
                        name: "FK_BaseDrink_tblsnsbases_BasesId",
                        column: x => x.BasesId,
                        principalTable: "tblsnsbases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseDrink_tblsnsdrinks_DrinksId",
                        column: x => x.DrinksId,
                        principalTable: "tblsnsdrinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuisineRecipe",
                columns: table => new
                {
                    CuisinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineRecipe", x => new { x.CuisinesId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_CuisineRecipe_tblsnscuisines_CuisinesId",
                        column: x => x.CuisinesId,
                        principalTable: "tblsnscuisines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuisineRecipe_tblsnsrecipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "tblsnsrecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseDrink_DrinksId",
                table: "BaseDrink",
                column: "DrinksId");

            migrationBuilder.CreateIndex(
                name: "IX_CuisineRecipe_RecipesId",
                table: "CuisineRecipe",
                column: "RecipesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseDrink");

            migrationBuilder.DropTable(
                name: "CuisineRecipe");

            migrationBuilder.DropTable(
                name: "tblsnsbases");

            migrationBuilder.DropTable(
                name: "tblsnsdrinks");

            migrationBuilder.DropTable(
                name: "tblsnscuisines");

            migrationBuilder.DropTable(
                name: "tblsnsrecipes");
        }
    }
}
