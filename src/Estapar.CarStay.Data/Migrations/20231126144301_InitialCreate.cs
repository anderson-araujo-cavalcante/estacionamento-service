using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estapar.CarStay.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Price_1aHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price_ExtraHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price_Monthly = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Passages",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GarageCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CarPlate = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CarBrand = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMethodCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passages", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Passages_Garages_GarageCode",
                        column: x => x.GarageCode,
                        principalTable: "Garages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passages_PaymentMethods_PaymentMethodCode",
                        column: x => x.PaymentMethodCode,
                        principalTable: "PaymentMethods",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passages_GarageCode",
                table: "Passages",
                column: "GarageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Passages_PaymentMethodCode",
                table: "Passages",
                column: "PaymentMethodCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passages");

            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "PaymentMethods");
        }
    }
}
