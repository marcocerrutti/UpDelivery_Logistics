using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpDelivery.Logistics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLogisticsSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssiignedAt",
                table: "DeliveryAssignments",
                newName: "AssignedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssignedAt",
                table: "DeliveryAssignments",
                newName: "AssiignedAt");
        }
    }
}
