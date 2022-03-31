using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStore.Infrastrucure.Migrations
{
    public partial class ComputerLaptopDisplay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CPU = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CPUSpeed = table.Column<double>(type: "float", nullable: false),
                    RAM = table.Column<int>(type: "int", nullable: false),
                    RAMType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    GPU = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GPUMemory = table.Column<int>(type: "int", nullable: false),
                    HDD = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "date", nullable: false),
                    DateTo = table.Column<DateTime>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Displays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Colors = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "date", nullable: false),
                    DateTo = table.Column<DateTime>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Displays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplaySize = table.Column<double>(type: "float", nullable: false),
                    DisplayResolution = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    CPU = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CpuSpeed = table.Column<double>(type: "float", nullable: false),
                    RAM = table.Column<int>(type: "int", nullable: false),
                    RamType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HDD = table.Column<int>(type: "int", nullable: false),
                    GPU = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GpuMemory = table.Column<int>(type: "int", nullable: false),
                    Battery = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "date", nullable: false),
                    DateTo = table.Column<DateTime>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Displays");

            migrationBuilder.DropTable(
                name: "Laptops");
        }
    }
}
