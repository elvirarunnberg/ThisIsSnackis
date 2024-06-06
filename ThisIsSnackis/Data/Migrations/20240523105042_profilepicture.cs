using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThisIsSnackis.Data.Migrations
{
    /// <inheritdoc />
    public partial class profilepicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicturePath",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserPicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPicture", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPicture");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
