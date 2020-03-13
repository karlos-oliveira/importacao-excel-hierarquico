using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Importador.Migrations
{
    public partial class CreateDataBaseImportador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ambiente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPai = table.Column<Guid>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    IdTipoAmbiente = table.Column<Guid>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambiente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportacaoAmbiente",
                columns: table => new
                {
                    IdImportacao = table.Column<Guid>(nullable: false),
                    DataImportacaoUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportacaoAmbiente", x => x.IdImportacao);
                });

            migrationBuilder.CreateTable(
                name: "TipoAmbiente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IsAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAmbiente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ambiente");

            migrationBuilder.DropTable(
                name: "ImportacaoAmbiente");

            migrationBuilder.DropTable(
                name: "TipoAmbiente");
        }
    }
}
