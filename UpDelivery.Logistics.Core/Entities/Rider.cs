using System;
using UpDelivery.Logistics.Core.Common;
using UpDelivery.Logistics.Core.Entities.Enums;

namespace UpDelivery.Logistics.Core.Entities;

public class Rider : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
    public string?  Email { get; set; }

    public VehicleType VehicleType {get; set;}
    public decimal MaxLoadKg {get; set;}

    public bool IsActive { get; set; } = true;

    public RiderStatus CurrentStatus { get; set;}
    
    public ICollection<DeliveryAssignment> Assignments {get; set;}  = new List<DeliveryAssignment>();

    public ICollection<DeliveryTracking> Trackings { get; set; } = new List<DeliveryTracking>();

    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
