using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace attendence_management_api.Migrations
{
    /// <inheritdoc />
    public partial class PrincipleKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_ClassInfo_Class",
                schema: "dbo",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ClassInfo_Class",
                schema: "dbo",
                table: "Student",
                column: "Class",
                principalSchema: "dbo",
                principalTable: "ClassInfo",
                principalColumn: "Class",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_ClassInfo_Class",
                schema: "dbo",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ClassInfo_Class",
                schema: "dbo",
                table: "Student",
                column: "Class",
                principalSchema: "dbo",
                principalTable: "ClassInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
