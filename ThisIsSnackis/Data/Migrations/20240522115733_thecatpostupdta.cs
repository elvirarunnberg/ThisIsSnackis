using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThisIsSnackis.Data.Migrations
{
    /// <inheritdoc />
    public partial class thecatpostupdta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Post_TheCategoryId",
                table: "Post",
                column: "TheCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Category_TheCategoryId",
                table: "Post",
                column: "TheCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Category_TheCategoryId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_TheCategoryId",
                table: "Post");
        }
    }
}
