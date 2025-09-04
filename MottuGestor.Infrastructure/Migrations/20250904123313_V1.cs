using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MottuGestor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patios",
                columns: table => new
                {
                    PatioId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patios", x => x.PatioId);
                });

            migrationBuilder.CreateTable(
                name: "Motos",
                columns: table => new
                {
                    MotoId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    PatioId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Placa = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Modelo = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Marca = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    RfidTag = table.Column<string>(type: "NVARCHAR2(32)", maxLength: 32, nullable: false),
                    Ano = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Problema = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motos", x => x.MotoId);
                    table.ForeignKey(
                        name: "FK_Motos_Patios_PatioId",
                        column: x => x.PatioId,
                        principalTable: "Patios",
                        principalColumn: "PatioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motos_PatioId",
                table: "Motos",
                column: "PatioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motos");

            migrationBuilder.DropTable(
                name: "Patios");
        }
    }
}
