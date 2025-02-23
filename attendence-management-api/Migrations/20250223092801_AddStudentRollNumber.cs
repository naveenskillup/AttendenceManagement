using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace attendence_management_api.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentRollNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RollNumber",
                schema: "dbo",
                table: "Student",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RollNumber",
                schema: "dbo",
                table: "Student");
        }
    }
}
