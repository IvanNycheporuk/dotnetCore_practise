using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiction.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 1, 2, "Atest" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 2, 22, "Btest" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 3, 12, "Ctest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
