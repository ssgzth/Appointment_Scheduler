using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment_Scheduler.Migrations
{
    /// <inheritdoc />
    public partial class addednewstatusColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "appointments");
        }
    }
}
