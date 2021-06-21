using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackerDB.Migrations
{
    public partial class chngModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractPIRs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    DateOfSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfComplete = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Closed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractPIRs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContractSMRs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    DateOfSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfCompleteFirstStage = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfCompleteSecondtStage = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedFirstStage = table.Column<bool>(type: "bit", nullable: false),
                    ClosedSecondStage = table.Column<bool>(type: "bit", nullable: false),
                    ContractSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractSMRs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfContracts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfContracts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Powerlines",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractPIRID = table.Column<int>(type: "int", nullable: true),
                    ConractSMRID = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powerlines", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Powerlines_ContractPIRs_ContractPIRID",
                        column: x => x.ContractPIRID,
                        principalTable: "ContractPIRs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Powerlines_ContractSMRs_ConractSMRID",
                        column: x => x.ConractSMRID,
                        principalTable: "ContractSMRs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InternalNotes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerlineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalNotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InternalNotes_Powerlines_PowerlineID",
                        column: x => x.PowerlineID,
                        principalTable: "Powerlines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternalNotes_PowerlineID",
                table: "InternalNotes",
                column: "PowerlineID");

            migrationBuilder.CreateIndex(
                name: "IX_Powerlines_ConractSMRID",
                table: "Powerlines",
                column: "ConractSMRID");

            migrationBuilder.CreateIndex(
                name: "IX_Powerlines_ContractPIRID",
                table: "Powerlines",
                column: "ContractPIRID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalNotes");

            migrationBuilder.DropTable(
                name: "TypeOfContracts");

            migrationBuilder.DropTable(
                name: "Powerlines");

            migrationBuilder.DropTable(
                name: "ContractPIRs");

            migrationBuilder.DropTable(
                name: "ContractSMRs");
        }
    }
}
