using System;
using UpDelivery.Logistics.Core.Common;

namespace UpDelivery.Logistics.Core.Entities;

public class ProofOfDelivery : BaseEntity
{
     public Guid LogisticsOrderId { get; set; }
    public LogisticsOrder LogisticsOrder { get; set; } = null!;

    public Guid DeliveredByRiderId { get; set; }

    public string RecipientName { get; set; } = string.Empty;
    public string RecipientPhone { get; set; } = string.Empty;

    public string? DeliveryImageUrl { get; set; }
    public string? SignatureUrl { get; set; }

    public string OtpCode { get; set; } = string.Empty;

    public DateTime DeliveredAt { get; set; }
}
