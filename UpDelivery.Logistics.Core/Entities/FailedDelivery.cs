using System;
using UpDelivery.Logistics.Core.Common;

namespace UpDelivery.Logistics.Core.Entities;

public class FailedDelivery:BaseEntity
{
     public Guid LogisticsOrderId { get; set; }
    public LogisticsOrder LogisticsOrder { get; set; } = null!;

    public string FailureReason { get; set; } = string.Empty;
    public string? FailureNotes { get; set; }

    public Guid ReportedBy { get; set; }

    public DateTime ReportedAt { get; set; }
}
