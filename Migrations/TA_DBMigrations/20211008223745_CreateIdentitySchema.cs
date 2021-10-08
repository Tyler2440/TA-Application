using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TAApplication.Migrations.TA_DBMigrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    uID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentDegree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    NumberHours = table.Column<int>(type: "int", nullable: false),
                    PersonalStatement = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    fluency = table.Column<int>(type: "int", nullable: false),
                    SemestersCompleted = table.Column<int>(type: "int", nullable: false),
                    LinkedInURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");
        }
    }
}
