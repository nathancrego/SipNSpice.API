using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SipNSpice.API.Migrations
{
    /// <inheritdoc />
    public partial class renamingtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseDrink_tblsnsbases_BasesId",
                table: "BaseDrink");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseDrink_tblsnsdrinks_DrinksId",
                table: "BaseDrink");

            migrationBuilder.DropForeignKey(
                name: "FK_CuisineRecipe_tblsnscuisines_CuisinesId",
                table: "CuisineRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_CuisineRecipe_tblsnsrecipes_RecipesId",
                table: "CuisineRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblsnsrecipes",
                table: "tblsnsrecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblsnsdrinks",
                table: "tblsnsdrinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblsnscuisines",
                table: "tblsnscuisines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblsnsbases",
                table: "tblsnsbases");

            migrationBuilder.RenameTable(
                name: "tblsnsrecipes",
                newName: "Recipes");

            migrationBuilder.RenameTable(
                name: "tblsnsdrinks",
                newName: "Drinks");

            migrationBuilder.RenameTable(
                name: "tblsnscuisines",
                newName: "Cuisines");

            migrationBuilder.RenameTable(
                name: "tblsnsbases",
                newName: "Bases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drinks",
                table: "Drinks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuisines",
                table: "Cuisines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bases",
                table: "Bases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDrink_Bases_BasesId",
                table: "BaseDrink",
                column: "BasesId",
                principalTable: "Bases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDrink_Drinks_DrinksId",
                table: "BaseDrink",
                column: "DrinksId",
                principalTable: "Drinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuisineRecipe_Cuisines_CuisinesId",
                table: "CuisineRecipe",
                column: "CuisinesId",
                principalTable: "Cuisines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuisineRecipe_Recipes_RecipesId",
                table: "CuisineRecipe",
                column: "RecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseDrink_Bases_BasesId",
                table: "BaseDrink");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseDrink_Drinks_DrinksId",
                table: "BaseDrink");

            migrationBuilder.DropForeignKey(
                name: "FK_CuisineRecipe_Cuisines_CuisinesId",
                table: "CuisineRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_CuisineRecipe_Recipes_RecipesId",
                table: "CuisineRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drinks",
                table: "Drinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuisines",
                table: "Cuisines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bases",
                table: "Bases");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "tblsnsrecipes");

            migrationBuilder.RenameTable(
                name: "Drinks",
                newName: "tblsnsdrinks");

            migrationBuilder.RenameTable(
                name: "Cuisines",
                newName: "tblsnscuisines");

            migrationBuilder.RenameTable(
                name: "Bases",
                newName: "tblsnsbases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblsnsrecipes",
                table: "tblsnsrecipes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblsnsdrinks",
                table: "tblsnsdrinks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblsnscuisines",
                table: "tblsnscuisines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblsnsbases",
                table: "tblsnsbases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDrink_tblsnsbases_BasesId",
                table: "BaseDrink",
                column: "BasesId",
                principalTable: "tblsnsbases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDrink_tblsnsdrinks_DrinksId",
                table: "BaseDrink",
                column: "DrinksId",
                principalTable: "tblsnsdrinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuisineRecipe_tblsnscuisines_CuisinesId",
                table: "CuisineRecipe",
                column: "CuisinesId",
                principalTable: "tblsnscuisines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuisineRecipe_tblsnsrecipes_RecipesId",
                table: "CuisineRecipe",
                column: "RecipesId",
                principalTable: "tblsnsrecipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
