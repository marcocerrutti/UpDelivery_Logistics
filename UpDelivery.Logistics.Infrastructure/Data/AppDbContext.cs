using System;
using Microsoft.EntityFrameworkCore;
using UpDelivery.Logistics.Core.Entities;

namespace UpDelivery.Logistics.Infrastructure.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<LogisticsOrder> LogisticsOrders {get; set;}
    public DbSet<Rider> Riders {get; set;}
    public DbSet<DeliveryAssignment> DeliveryAssignments {get; set;}
    public DbSet<DeliveryTracking> DeliveryTrackings {get; set;}
    public DbSet<ProofOfDelivery> ProofsOfDelivery {get; set;}
    public DbSet<DeliveryStatusHistory> DeliveryStatusHistories {get; set;}
    public DbSet<Vehicle> Vehicles {get; set;}
    public DbSet<FailedDelivery> FailedDeliveries {get; set;}
}
