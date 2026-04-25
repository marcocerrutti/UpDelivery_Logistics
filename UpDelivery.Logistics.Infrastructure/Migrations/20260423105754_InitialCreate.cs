using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpDelivery.Logistics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogisticsOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChefreshOrderId = table.Column<string>(type: "TEXT", nullable: false),
                    FarmId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PickupAddress = table.Column<string>(type: "TEXT", nullable: false),
                    PickupLatitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    PickupLongitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryLatitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    DeliveryLongitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    DeliveryWindowStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryWindowEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryFee = table.Column<decimal>(type: "TEXT", nullable: false),
                    OrderWeightKg = table.Column<decimal>(type: "TEXT", nullable: false),
                    DeliveryType = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogisticsOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Riders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    VehicleType = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxLoadKg = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryStatusHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LogisticsOrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OldStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    NewStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChangeReason = table.Column<string>(type: "TEXT", nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryStatusHistories_LogisticsOrders_LogisticsOrderId",
                        column: x => x.LogisticsOrderId,
                        principalTable: "LogisticsOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FailedDeliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LogisticsOrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FailureReason = table.Column<string>(type: "TEXT", nullable: false),
                    FailureNotes = table.Column<string>(type: "TEXT", nullable: true),
                    ReportedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailedDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FailedDeliveries_LogisticsOrders_LogisticsOrderId",
                        column: x => x.LogisticsOrderId,
                        principalTable: "LogisticsOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProofsOfDelivery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LogisticsOrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeliveredByRiderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecipientName = table.Column<string>(type: "TEXT", nullable: false),
                    RecipientPhone = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    SignatureUrl = table.Column<string>(type: "TEXT", nullable: true),
                    OtpCode = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveredAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProofsOfDelivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProofsOfDelivery_LogisticsOrders_LogisticsOrderId",
                        column: x => x.LogisticsOrderId,
                        principalTable: "LogisticsOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LogisticsOrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RiderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssignedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssiignedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UnassignedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryAssignments_LogisticsOrders_LogisticsOrderId",
                        column: x => x.LogisticsOrderId,
                        principalTable: "LogisticsOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryAssignments_Riders_RiderId",
                        column: x => x.RiderId,
                        principalTable: "Riders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryTrackings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LogisticsOrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RiderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Latitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    Longitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    SpeedKmh = table.Column<decimal>(type: "TEXT", nullable: false),
                    Heading = table.Column<decimal>(type: "TEXT", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryTrackings_LogisticsOrders_LogisticsOrderId",
                        column: x => x.LogisticsOrderId,
                        principalTable: "LogisticsOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryTrackings_Riders_RiderId",
                        column: x => x.RiderId,
                        principalTable: "Riders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RiderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlateNumber = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleType = table.Column<int>(type: "INTEGER", nullable: false),
                    CapacityKg = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Riders_RiderId",
                        column: x => x.RiderId,
                        principalTable: "Riders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAssignments_LogisticsOrderId",
                table: "DeliveryAssignments",
                column: "LogisticsOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAssignments_RiderId",
                table: "DeliveryAssignments",
                column: "RiderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryStatusHistories_LogisticsOrderId",
                table: "DeliveryStatusHistories",
                column: "LogisticsOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTrackings_LogisticsOrderId",
                table: "DeliveryTrackings",
                column: "LogisticsOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTrackings_RiderId",
                table: "DeliveryTrackings",
                column: "RiderId");

            migrationBuilder.CreateIndex(
                name: "IX_FailedDeliveries_LogisticsOrderId",
                table: "FailedDeliveries",
                column: "LogisticsOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProofsOfDelivery_LogisticsOrderId",
                table: "ProofsOfDelivery",
                column: "LogisticsOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RiderId",
                table: "Vehicles",
                column: "RiderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryAssignments");

            migrationBuilder.DropTable(
                name: "DeliveryStatusHistories");

            migrationBuilder.DropTable(
                name: "DeliveryTrackings");

            migrationBuilder.DropTable(
                name: "FailedDeliveries");

            migrationBuilder.DropTable(
                name: "ProofsOfDelivery");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "LogisticsOrders");

            migrationBuilder.DropTable(
                name: "Riders");
        }
    }
}
