using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class Index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Insurances_InsuredId",
                table: "Insurances");

            migrationBuilder.DropIndex(
                name: "IX_Insurances_VehicleId",
                table: "Insurances");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_InsuredId",
                table: "Insurances",
                column: "InsuredId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_VehicleId",
                table: "Insurances",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Insurances_InsuredId",
                table: "Insurances");

            migrationBuilder.DropIndex(
                name: "IX_Insurances_VehicleId",
                table: "Insurances");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_InsuredId",
                table: "Insurances",
                column: "InsuredId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_VehicleId",
                table: "Insurances",
                column: "VehicleId",
                unique: true);
        }
    }
}
