using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanAssetApi.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    underwarranty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfManufacture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CpuMonitorInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetTag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuMonitorInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetCustodians",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCustodians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetCustodians_BranchLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "BranchLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Desktops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CpuMonitorInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustodianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RamSize = table.Column<int>(type: "int", nullable: false),
                    SupportOfficer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desktops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desktops_AssetCustodians_CustodianId",
                        column: x => x.CustodianId,
                        principalTable: "AssetCustodians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Desktops_AssetInfo_AssetInfoId",
                        column: x => x.AssetInfoId,
                        principalTable: "AssetInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Desktops_CpuMonitorInfos_CpuMonitorInfoId",
                        column: x => x.CpuMonitorInfoId,
                        principalTable: "CpuMonitorInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustodianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RamSize = table.Column<int>(type: "int", nullable: false),
                    SupportOfficer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laptops_AssetCustodians_CustodianId",
                        column: x => x.CustodianId,
                        principalTable: "AssetCustodians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Laptops_AssetInfo_AssetInfoId",
                        column: x => x.AssetInfoId,
                        principalTable: "AssetInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustodians_LocationId",
                table: "AssetCustodians",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Desktops_AssetInfoId",
                table: "Desktops",
                column: "AssetInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Desktops_CpuMonitorInfoId",
                table: "Desktops",
                column: "CpuMonitorInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Desktops_CustodianId",
                table: "Desktops",
                column: "CustodianId");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_AssetInfoId",
                table: "Laptops",
                column: "AssetInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_CustodianId",
                table: "Laptops",
                column: "CustodianId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desktops");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "CpuMonitorInfos");

            migrationBuilder.DropTable(
                name: "AssetCustodians");

            migrationBuilder.DropTable(
                name: "AssetInfo");

            migrationBuilder.DropTable(
                name: "BranchLocations");
        }
    }
}
