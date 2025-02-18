using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace attendence_management_api.Migrations
{
    /// <inheritdoc />
    public partial class ClassStudentOnetoMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassInfoId",
                schema: "dbo",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassInfoId",
                schema: "dbo",
                table: "Student",
                column: "ClassInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ClassInfo_ClassInfoId",
                schema: "dbo",
                table: "Student",
                column: "ClassInfoId",
                principalSchema: "dbo",
                principalTable: "ClassInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_ClassInfo_ClassInfoId",
                schema: "dbo",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_ClassInfoId",
                schema: "dbo",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ClassInfoId",
                schema: "dbo",
                table: "Student");
        }
    }
}
