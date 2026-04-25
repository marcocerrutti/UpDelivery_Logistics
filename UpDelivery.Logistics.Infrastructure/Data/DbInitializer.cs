using Microsoft.EntityFrameworkCore;
using UpDelivery.Logistics.Core.Entities;
using UpDelivery.Logistics.Core.Entities.Enums;

namespace UpDelivery.Logistics.Infrastructure.Data;

public class DbInitializer
{
    public static async Task SeedData (AppDbContext context)
    {
        
        if(await context.Riders.AnyAsync()) return;
        var rider1 = new Rider
        {
           Id = Guid.NewGuid(),
            FirstName = "Daniel",
            LastName = "Musa",
            PhoneNumber = "08031234567",
            Email = "daniel@updelivery.com",
            VehicleType = VehicleType.Motorcycle,
            MaxLoadKg = 30,
            IsActive = true,
            CurrentStatus = RiderStatus.Available
        };

        var rider2 = new Rider
        {
             Id = Guid.NewGuid(),
            FirstName = "Grace",
            LastName = "Okoro",
            PhoneNumber = "08039876543",
            Email = "grace@updelivery.com",
            VehicleType = VehicleType.smallVan,
            MaxLoadKg = 100,
            IsActive = true,
            CurrentStatus = RiderStatus.Busy
        };
        await context.Riders.AddRangeAsync(rider1, rider2);
        
        // Vehicles
        var vehicle1 = new Vehicle
        {
            Id = Guid.NewGuid(),
            RiderId = rider1.Id,
            PlateNumber = "ABC-123XY",
            VehicleType = VehicleType.Motorcycle,
            CapacityKg = 30,
            IsActive = true
        };
       
        var vehicle2 = new Vehicle
        {
            Id = Guid.NewGuid(),
            RiderId = rider2.Id,
            PlateNumber = "XYZ-789AB",
            VehicleType = VehicleType.smallVan,
            CapacityKg = 100,
            IsActive = true
        };
        await context.Vehicles.AddRangeAsync(vehicle1, vehicle2);

        // Logistics Orders
        var order1 = new LogisticsOrder
        {
             Id = Guid.NewGuid(),
            ChefreshOrderId = "CHEF-1001",
            FarmId = Guid.NewGuid(),
            PickupAddress = "AgroHarvest Farm, Kubwa, Abuja",
            PickupLatitude = 9.1530m,
            PickupLongitude = 7.3220m,
            DeliveryAddress = "Wuse Zone 4, Abuja",
            DeliveryLatitude = 9.0765m,
            DeliveryLongitude = 7.3986m,
            DeliveryWindowStart = DateTime.UtcNow,
            DeliveryWindowEnd = DateTime.UtcNow.AddHours(3),
            DeliveryFee = 2500,
            OrderWeightKg = 15,
            DeliveryType = DeliveryType.SameDay,
            Status = DeliveryStatus.Assigned,
            City = "Abuja"
        };

        var order2 = new LogisticsOrder
        {
             Id = Guid.NewGuid(),
            ChefreshOrderId = "CHEF-1002",
            FarmId = Guid.NewGuid(),
            PickupAddress = "AgroHarvest Farm, Gwagwalada",
            PickupLatitude = 8.9430m,
            PickupLongitude = 7.0870m,
            DeliveryAddress = "Maitama, Abuja",
            DeliveryLatitude = 9.0850m,
            DeliveryLongitude = 7.4950m,
            DeliveryWindowStart = DateTime.UtcNow,
            DeliveryWindowEnd = DateTime.UtcNow.AddHours(5),
            DeliveryFee = 4000,
            OrderWeightKg = 40,
            DeliveryType = DeliveryType.Scheduled,
            Status = DeliveryStatus.PickedUp,
            City = "Abuja"
        };
        await context.LogisticsOrders.AddRangeAsync(order1, order2);

        // Assignments
        var assignment1 = new DeliveryAssignment
        {
            Id = Guid.NewGuid(),
            LogisticsOrderId = order1.Id,
            RiderId = rider1.Id,
            AssignedBy = Guid.NewGuid(),
            AssignedAt = DateTime.UtcNow,
            IsActive = true
        };

        var assignment2 = new DeliveryAssignment
        {
            Id = Guid.NewGuid(),
            LogisticsOrderId = order2.Id,
            RiderId = rider2.Id,
            AssignedBy = Guid.NewGuid(),
            AssignedAt = DateTime.UtcNow,
            IsActive = true
        };
        await context.DeliveryAssignments.AddRangeAsync(assignment1, assignment2);

         // Tracking
        var tracking1 = new DeliveryTracking
        {
            Id = Guid.NewGuid(),
            LogisticsOrderId = order1.Id,
            RiderId = rider1.Id,
            Latitude = 9.0800m,
            Longitude = 7.3900m,
            SpeedKmh = 45,
            Heading = 180,
            RecordedAt = DateTime.UtcNow
        };

        var tracking2 = new DeliveryTracking
        {
            Id = Guid.NewGuid(),
            LogisticsOrderId = order2.Id,
            RiderId = rider2.Id,
            Latitude = 9.0820m,
            Longitude = 7.4200m,
            SpeedKmh = 35,
            Heading = 90,
            RecordedAt = DateTime.UtcNow
        };

        await context.DeliveryTrackings.AddRangeAsync(tracking1, tracking2);

        // Status History
        var history1 = new DeliveryStatusHistory
        {
            Id = Guid.NewGuid(),
            LogisticsOrderId = order1.Id,
            OldStatus = DeliveryStatus.Created,
            NewStatus = DeliveryStatus.Assigned,
            ChangedBy = Guid.NewGuid(),
            ChangeReason = "Auto assigned to available rider",
            ChangedAt = DateTime.UtcNow
        };

        var history2 = new DeliveryStatusHistory
        {
            Id = Guid.NewGuid(),
            LogisticsOrderId = order2.Id,
            OldStatus = DeliveryStatus.Assigned,
            NewStatus = DeliveryStatus.PickedUp,
            ChangedBy = rider2.Id,
            ChangeReason = "Order picked from farm",
            ChangedAt = DateTime.UtcNow
        };

        await context.DeliveryStatusHistories.AddRangeAsync(history1, history2);

        // Proof of Delivery
        var proof = new ProofOfDelivery
        {
            Id = Guid.NewGuid(),
            LogisticsOrderId = order2.Id,
            DeliveredByRiderId = rider2.Id,
            RecipientName = "Mr. Adewale",
            RecipientPhone = "08030001111",
            DeliveryImageUrl = "uploads/proof1.jpg",
            SignatureUrl = "uploads/signature1.png",
            OtpCode = "123456",
            DeliveredAt = DateTime.UtcNow
        };

        await context.ProofsOfDelivery.AddAsync(proof);

        // Failed Delivery
        var failed = new FailedDelivery
        {
            Id = Guid.NewGuid(),
            LogisticsOrderId = order1.Id,
            FailureReason = "Customer unavailable",
            FailureNotes = "Recipient phone unreachable",
            ReportedBy = rider1.Id,
            ReportedAt = DateTime.UtcNow
        };

        await context.FailedDeliveries.AddAsync(failed);
        await context.SaveChangesAsync();
    }
}
