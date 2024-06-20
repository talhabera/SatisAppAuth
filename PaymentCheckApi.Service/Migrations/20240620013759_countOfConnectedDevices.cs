using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentCheckApi.Service.Migrations
{
    public partial class countOfConnectedDevices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfConnectedDevices",
                schema: "dbo",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfConnectedDevices",
                schema: "dbo",
                table: "Customer");
        }
    }
}
