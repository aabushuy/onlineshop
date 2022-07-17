using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.DataAccess.Migrations
{
    public partial class users_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "SiteUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "SiteUsers");
        }
    }
}
