using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpDelivery.Logistics.Core.Entities;
using UpDelivery.Logistics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace UpDelivery.Logistics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticsOrdersController(AppDbContext context) : BaseAPIController
    {
       [HttpGet]
       public async Task<ActionResult<List<LogisticsOrder>>> GetOrders()
        {
            return await context.LogisticsOrders.ToListAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LogisticsOrder>> GetOrder(Guid id)
        {
            var order = await context.LogisticsOrders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        
    }
}
