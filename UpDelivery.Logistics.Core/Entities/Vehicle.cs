using System;
using UpDelivery.Logistics.Core.Common;
using UpDelivery.Logistics.Core.Entities.Enums;

namespace UpDelivery.Logistics.Core.Entities;

public class Vehicle : BaseEntity
{
    public Guid RiderId { get; set; }
    public Rider Rider { get; set; } = null!;

    public string PlateNumber { get; set; } = string.Empty;
    public VehicleType VehicleType { get; set; }
    public decimal CapacityKg { get; set; }
    public bool IsActive { get; set; }
}
