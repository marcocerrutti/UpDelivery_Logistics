using System;
using UpDelivery.Logistics.Core.Common;

namespace UpDelivery.Logistics.Core.Entities;

public class DeliveryTracking : BaseEntity
{
    public Guid LogisticsOrderId { get; set; }
    public LogisticsOrder LogisticsOrder { get; set; } = null!;

    public Guid RiderId { get; set; }
    public Rider Rider { get; set; } = null!;

    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public decimal SpeedKmh { get; set; }
    public decimal Heading { get; set; }

    public DateTime RecordedAt { get; set; }
}
