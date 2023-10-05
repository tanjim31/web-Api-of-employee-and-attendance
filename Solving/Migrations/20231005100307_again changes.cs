using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solving.Migrations
{
    /// <inheritdoc />
    public partial class againchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendances_employeetbs_EmployeetbemployeeId",
                table: "attendances");

            migrationBuilder.DropIndex(
                name: "IX_attendances_EmployeetbemployeeId",
                table: "attendances");

            migrationBuilder.DropColumn(
                name: "EmployeetbemployeeId",
                table: "attendances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeetbemployeeId",
                table: "attendances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_attendances_EmployeetbemployeeId",
                table: "attendances",
                column: "EmployeetbemployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_attendances_employeetbs_EmployeetbemployeeId",
                table: "attendances",
                column: "EmployeetbemployeeId",
                principalTable: "employeetbs",
                principalColumn: "employeeId");
        }
    }
}
