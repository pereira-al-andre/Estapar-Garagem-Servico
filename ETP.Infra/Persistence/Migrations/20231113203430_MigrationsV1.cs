using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETP.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormasPagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(3)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    PrecoHora = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    PrecoHorasExtra = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    PrecoMensalista = table.Column<decimal>(type: "numeric(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodGaragem = table.Column<string>(type: "varchar(10)", nullable: false),
                    FormasPagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GaragemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarroPlaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarroMarca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarroModelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataHoraEntrada = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataHoraSaida = table.Column<DateTime>(type: "datetime", nullable: true),
                    CodFormaPagamento = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passagem_FormasPagamento_FormasPagamentoId",
                        column: x => x.FormasPagamentoId,
                        principalTable: "FormasPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passagem_Garagem_GaragemId",
                        column: x => x.GaragemId,
                        principalTable: "Garagem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_FormasPagamentoId",
                table: "Passagem",
                column: "FormasPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_GaragemId",
                table: "Passagem",
                column: "GaragemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passagem");

            migrationBuilder.DropTable(
                name: "FormasPagamento");

            migrationBuilder.DropTable(
                name: "Garagem");
        }
    }
}
