using Microsoft.EntityFrameworkCore.Migrations;

namespace HH.Migrations.Promo
{
    public partial class AtTabPromo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Promo",
                newName: "PrecoAtual");

            migrationBuilder.AddColumn<double>(
                name: "PrecoAnterior",
                table: "Promo",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoAnterior",
                table: "Promo");

            migrationBuilder.RenameColumn(
                name: "PrecoAtual",
                table: "Promo",
                newName: "Preco");
        }
    }
}
