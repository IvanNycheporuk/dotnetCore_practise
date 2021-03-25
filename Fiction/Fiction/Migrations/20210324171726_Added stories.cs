using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiction.Migrations
{
    public partial class Addedstories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Atest" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Btest" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Ctest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stories");
        }
    }
}
