using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace attendence_management_api.Migrations
{
    /// <inheritdoc />
    public partial class AddAttendenceStatusNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassTeacherId",
                schema: "dbo",
                table: "ClassInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AttendanceStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceDate = table.Column<DateTime>(type: "Date", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceStatus_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "dbo",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceStatus_StudentId",
                schema: "dbo",
                table: "AttendanceStatus",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceStatus",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "ClassTeacherId",
                schema: "dbo",
                table: "ClassInfo");
        }
    }
}
