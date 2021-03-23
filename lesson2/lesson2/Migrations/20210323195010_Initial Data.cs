using Microsoft.EntityFrameworkCore.Migrations;

namespace lesson2.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFake = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "AuthorName", "IsFake", "Text", "Title" },
                values: new object[,]
                {
                    { 1, "Jeremy Clarkson", true, "", "Humanity finally colonized the Mercury!!" },
                    { 2, "Svetlana Sokolova", true, "", "Increase your lifespan by 10 years, every morning you need..." },
                    { 3, "John Jones", false, "", "Scientists estimed the time of the vaccine invension: it is a summer of 2021" },
                    { 4, "Cerol Denvers", false, "", "Ukraine reduces the cost of its obligations!" },
                    { 5, "Jimmy Felon", true, "", "A species were discovered in Africa: it is blue legless cat" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
