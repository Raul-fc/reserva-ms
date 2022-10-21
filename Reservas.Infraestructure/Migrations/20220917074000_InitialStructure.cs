using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservas.Infraestructure.Migrations
{
    public partial class InitialStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asiento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nroAsiento = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    estado = table.Column<string>(type: "char(1)", nullable: false),
                    AvionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VueloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nroReserva = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    costo = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    fechaVuelo = table.Column<DateTime>(type: "date", nullable: false),
                    hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    horaLimite = table.Column<TimeSpan>(type: "time", nullable: false),
                    estado = table.Column<string>(type: "char(1)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    IdVuelo = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    importe = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    importePagado = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pago_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservaAnulado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaAnulado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaAnulado_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VueloReserva",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pasajero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nroDocumento = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    costo = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VueloReserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VueloReserva_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nroFactura = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    importe = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    PagoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factura_Pago_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recibo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nroRecibo = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    importeTotal = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    importePagado = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    PagoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recibo_Pago_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_PagoId",
                table: "Factura",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_ReservaId",
                table: "Pago",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibo_PagoId",
                table: "Recibo",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaAnulado_ReservaId",
                table: "ReservaAnulado",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_VueloReserva_ReservaId",
                table: "VueloReserva",
                column: "ReservaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asiento");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Recibo");

            migrationBuilder.DropTable(
                name: "ReservaAnulado");

            migrationBuilder.DropTable(
                name: "VueloReserva");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Reserva");
        }
    }
}
