using Microsoft.EntityFrameworkCore.Migrations;

namespace Supermercados.Migrations
{
    public partial class MigraciónInicial : Migration
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

            migrationBuilder.InsertData(
                table: "AvisoItems",
                columns: new[] { "Id", "CodigoPostal", "Comentario", "Producto", "Supermercado" },
                values: new object[] { 1, 21110, "No queda leche puleva", "leche", "Dia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvisoItems");
        }
    }
}
