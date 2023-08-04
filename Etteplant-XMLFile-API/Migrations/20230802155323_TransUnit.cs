using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Etteplant_XMLFile_API.Migrations
{
    /// <inheritdoc />
    public partial class TransUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransUnits", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TransUnits",
                columns: new[] { "Id", "Source", "Target" },
                values: new object[,]
                {
                    { 42006, "WARNING", "VARNING" },
                    { 42007, "Note", "Obs!" },
                    { 42008, "DANGER", "FARA" },
                    { 42009, "CAUTION", "FÖRSIKTIGHET" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransUnits");
        }
    }
}
