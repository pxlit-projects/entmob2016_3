using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace VegiSens.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Humidity",
                columns: table => new
                {
                    HumidityID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaxHumidity = table.Column<double>(nullable: false),
                    MinHumidity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humidity", x => x.HumidityID);
                });
            migrationBuilder.CreateTable(
                name: "Light",
                columns: table => new
                {
                    LightID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaxLight = table.Column<double>(nullable: false),
                    MinLight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Light", x => x.LightID);
                });
            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    TemperatureID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaxTemperature = table.Column<double>(nullable: false),
                    MinTemperature = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.TemperatureID);
                });
            migrationBuilder.CreateTable(
                name: "GrowableItem",
                columns: table => new
                {
                    GrowableItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    HumidityID = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    LightID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TemperatureID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrowableItem", x => x.GrowableItemID);
                    table.ForeignKey(
                        name: "FK_GrowableItem_Humidity_HumidityID",
                        column: x => x.HumidityID,
                        principalTable: "Humidity",
                        principalColumn: "HumidityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrowableItem_Light_LightID",
                        column: x => x.LightID,
                        principalTable: "Light",
                        principalColumn: "LightID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrowableItem_Temperature_TemperatureID",
                        column: x => x.TemperatureID,
                        principalTable: "Temperature",
                        principalColumn: "TemperatureID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("GrowableItem");
            migrationBuilder.DropTable("Humidity");
            migrationBuilder.DropTable("Light");
            migrationBuilder.DropTable("Temperature");
        }
    }
}
