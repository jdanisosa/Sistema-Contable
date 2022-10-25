using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Contable.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grupo_Contables",
                columns: table => new
                {
                    Id_Grupo_Contable = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Grupo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo_Contables", x => x.Id_Grupo_Contable);
                });

            migrationBuilder.CreateTable(
                name: "Partida_Diarios",
                columns: table => new
                {
                    Id_Partida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correlativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero_Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida_Diarios", x => x.Id_Partida);
                });

            migrationBuilder.CreateTable(
                name: "Clasificacion_Grupos",
                columns: table => new
                {
                    Id_Clasificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Clasificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Grupo_Contable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificacion_Grupos", x => x.Id_Clasificacion);
                    table.ForeignKey(
                        name: "FK_Clasificacion_Grupos_Grupo_Contables_Id_Grupo_Contable",
                        column: x => x.Id_Grupo_Contable,
                        principalTable: "Grupo_Contables",
                        principalColumn: "Id_Grupo_Contable",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id_Cuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Cuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre_Cuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Saldo_Actual = table.Column<float>(type: "real", nullable: false),
                    Id_Clasificacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id_Cuenta);
                    table.ForeignKey(
                        name: "FK_Cuentas_Clasificacion_Grupos_Id_Clasificacion",
                        column: x => x.Id_Clasificacion,
                        principalTable: "Clasificacion_Grupos",
                        principalColumn: "Id_Clasificacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Partida_Diarios",
                columns: table => new
                {
                    Id_Cuenta = table.Column<int>(type: "int", nullable: false),
                    Id_Partida = table.Column<int>(type: "int", nullable: false),
                    Debe = table.Column<float>(type: "real", nullable: false),
                    Haber = table.Column<float>(type: "real", nullable: false),
                    Saldo = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Partida_Diarios", x => new { x.Id_Cuenta, x.Id_Partida });
                    table.ForeignKey(
                        name: "FK_Detalle_Partida_Diarios_Cuentas_Id_Cuenta",
                        column: x => x.Id_Cuenta,
                        principalTable: "Cuentas",
                        principalColumn: "Id_Cuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Partida_Diarios_Partida_Diarios_Id_Partida",
                        column: x => x.Id_Partida,
                        principalTable: "Partida_Diarios",
                        principalColumn: "Id_Partida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clasificacion_Grupos_Id_Grupo_Contable",
                table: "Clasificacion_Grupos",
                column: "Id_Grupo_Contable");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_Id_Clasificacion",
                table: "Cuentas",
                column: "Id_Clasificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Partida_Diarios_Id_Partida",
                table: "Detalle_Partida_Diarios",
                column: "Id_Partida");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Partida_Diarios");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Partida_Diarios");

            migrationBuilder.DropTable(
                name: "Clasificacion_Grupos");

            migrationBuilder.DropTable(
                name: "Grupo_Contables");
        }
    }
}
