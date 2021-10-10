using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackerDB.Migrations
{
    public partial class AdditonaAgreemenAnStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedFirstStage",
                table: "ContractSMRs");

            migrationBuilder.DropColumn(
                name: "ClosedSecondStage",
                table: "ContractSMRs");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ContractSMRs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdditionalAgreementPIRs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewCloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractPIRID = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    DateOfSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewSumm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalAgreementPIRs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdditionalAgreementPIRs_ContractPIRs_ContractPIRID",
                        column: x => x.ContractPIRID,
                        principalTable: "ContractPIRs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalAgreementSMRs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewCloseFirstStage = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewCloseSecondtStage = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractSMRID = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    DateOfSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewSumm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalAgreementSMRs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdditionalAgreementSMRs_ContractSMRs_ContractSMRID",
                        column: x => x.ContractSMRID,
                        principalTable: "ContractSMRs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalAgreementPIRs_ContractPIRID",
                table: "AdditionalAgreementPIRs",
                column: "ContractPIRID");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalAgreementSMRs_ContractSMRID",
                table: "AdditionalAgreementSMRs",
                column: "ContractSMRID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalAgreementPIRs");

            migrationBuilder.DropTable(
                name: "AdditionalAgreementSMRs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ContractSMRs");

            migrationBuilder.AddColumn<bool>(
                name: "ClosedFirstStage",
                table: "ContractSMRs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClosedSecondStage",
                table: "ContractSMRs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
