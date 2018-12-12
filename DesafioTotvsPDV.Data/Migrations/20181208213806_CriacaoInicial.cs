using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioTotvsPDV.Data.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ValorVenda = table.Column<decimal>(nullable: false),
                    ValorPago = table.Column<decimal>(nullable: false),
                    ValorTroco = table.Column<decimal>(nullable: false),
                    DataTransacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTrocoPagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPagamento = table.Column<Guid>(nullable: false),
                    ValorObjetoTroco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTrocoPagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTrocoPagamento_Pagamento_IdPagamento",
                        column: x => x.IdPagamento,
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTrocoPagamento_IdPagamento",
                table: "ItemTrocoPagamento",
                column: "IdPagamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTrocoPagamento");

            migrationBuilder.DropTable(
                name: "Pagamento");
        }
    }
}
