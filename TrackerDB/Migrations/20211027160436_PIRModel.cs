using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackerDB.Migrations
{
    public partial class PIRModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Closed",
                table: "ContractPIRs");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ContractPIRs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ContractPIRs");

            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "ContractPIRs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
