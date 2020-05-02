using Microsoft.EntityFrameworkCore.Migrations;

namespace Supermercados.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvisoItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supermercado = table.Column<string>(nullable: false),
                    CodigoPostal = table.Column<int>(nullable: false),
                    Producto = table.Column<string>(nullable: false),
                    Comentario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvisoItems", x => x.Id);
                });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvisoItems");
        }
    }
}
