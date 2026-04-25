using System;
using UpDelivery.Logistics.Core.Common;

namespace UpDelivery.Logistics.Core.Entities;

public class DeliveryAssignment: BaseEntity
{
    public Guid LogisticsOrderId {get;set;}
    public LogisticsOrder LogisticsOrder { get; set; } = null!;

    public Guid RiderId {get; set;}
    public Rider Rider { get; set; } = null!;

    public Guid AssignedBy {get;set;}

    public DateTime AssignedAt { get; set; }
    public DateTime? UnassignedAt { get; set; }

    public bool IsActive { get; set; } = true;
}
