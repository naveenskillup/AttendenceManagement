using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace attendence_management_api.Migrations
{
    /// <inheritdoc />
    public partial class ClassInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassInfo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false, defaultValue: 50),
                    Section = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassInfo", x => x.Id);
                    table.UniqueConstraint("AK_ClassInfo_Class", x => x.Class);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassInfo",
                schema: "dbo");
        }
    }
}
