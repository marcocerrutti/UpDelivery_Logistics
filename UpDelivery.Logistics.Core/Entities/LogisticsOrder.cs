using System;
using UpDelivery.Logistics.Core.Common;
using UpDelivery.Logistics.Core.Entities.Enums;

namespace UpDelivery.Logistics.Core.Entities;

public class LogisticsOrder : BaseEntity
{
    public string ChefreshOrderId { get; set; } = string.Empty;
    public Guid FarmId { get; set; }

    public string PickupAddress { get; set; } = string.Empty;
    public decimal PickupLatitude { get; set; }
    public decimal PickupLongitude { get; set; }

    public string DeliveryAddress { get; set; } = string.Empty;
    public decimal DeliveryLatitude { get; set; }
    public decimal DeliveryLongitude { get; set; }

    public DateTime DeliveryWindowStart { get; set; }
    public DateTime DeliveryWindowEnd { get; set; }

    public decimal DeliveryFee { get; set; }
    public decimal OrderWeightKg { get; set; }

    public DeliveryType DeliveryType { get; set; }
    public DeliveryStatus Status { get; set; }

    public string City { get; set; } = string.Empty;

    public ICollection<DeliveryAssignment> Assignments { get; set; }
        = new List<DeliveryAssignment>();

    public ICollection<DeliveryTracking> Trackings { get; set; }
        = new List<DeliveryTracking>();

    public ICollection<DeliveryStatusHistory> StatusHistories { get; set; }
        = new List<DeliveryStatusHistory>();

    public ProofOfDelivery? ProofOfDelivery { get; set; }

    public FailedDelivery? FailedDelivery { get; set; }

}
