using System;
using UpDelivery.Logistics.Core.Common;
using UpDelivery.Logistics.Core.Entities.Enums;

namespace UpDelivery.Logistics.Core.Entities;

public class DeliveryStatusHistory: BaseEntity
{
    public Guid LogisticsOrderId { get; set; }
    public LogisticsOrder LogisticsOrder { get; set; } = null!;

    public DeliveryStatus OldStatus { get; set; }
    public DeliveryStatus NewStatus { get; set; }

    public Guid ChangedBy { get; set; }

    public string? ChangeReason { get; set; }

    public DateTime ChangedAt { get; set; }
}
