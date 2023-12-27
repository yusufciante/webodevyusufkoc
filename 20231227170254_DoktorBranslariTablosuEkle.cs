using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hastanerandevu.Migrations
{
    /// <inheritdoc />
    public partial class DoktorBranslariTablosuEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoktorBranslari",
                columns: table => new
                {
                    Id=table.Column<int>(type:"int",nullable: false)
                        .Annotation("SqlServer:Identity,"1,1"),
                    Ad=table.Column<string>(type:"nvarchar(max)",nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey")
                }
                )
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
