using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hastanerandevu.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoktorBranslari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorBranslari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poliklinik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorMesai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doktorBransId = table.Column<int>(type: "int", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doktorlar_DoktorBranslari_doktorBransId",
                        column: x => x.doktorBransId,
                        principalTable: "DoktorBranslari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_doktorBransId",
                table: "Doktorlar",
                column: "doktorBransId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "DoktorBranslari");
        }
    }
}
