using Microsoft.EntityFrameworkCore.Migrations;

namespace TAApplication.Migrations
{
    public partial class CreateIdentitySchema2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasApplication",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasApplication",
                table: "AspNetUsers");
        }
    }
}
