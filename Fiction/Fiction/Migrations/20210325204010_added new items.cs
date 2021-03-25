using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiction.Migrations
{
    public partial class addednewitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "Name" },
                values: new object[] { 21, "Test" });

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Frodo");

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Age", "Name", "StoryId" },
                values: new object[] { 42, "Joel", 2 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "Name", "StoryId" },
                values: new object[,]
                {
                    { 4, 32, "Sara", 2 },
                    { 5, 22, "PotM", 2 },
                    { 6, 62, "Warden", 2 },
                    { 7, 22, "Naga", 2 },
                    { 8, 12, "Harry", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Stories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Some great story");

            migrationBuilder.UpdateData(
                table: "Stories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Awesome story with unexpected ending");

            migrationBuilder.UpdateData(
                table: "Stories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Great news about that story");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "Name" },
                values: new object[] { 2, "Atest" });

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Btest");

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Age", "Name", "StoryId" },
                values: new object[] { 12, "Ctest", 3 });

            migrationBuilder.UpdateData(
                table: "Stories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Atest");

            migrationBuilder.UpdateData(
                table: "Stories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Btest");

            migrationBuilder.UpdateData(
                table: "Stories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Ctest");
        }
    }
}
