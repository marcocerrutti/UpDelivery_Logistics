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

        [HttpPost]
        public async Task<ActionResult<LogisticsOrder>> CreateOrder(LogisticsOrder order)
        {
            context.LogisticsOrders.Add(order);
            await context.SaveChangesAsync();
            return order;
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateOrder(Guid id, LogisticsOrder order)
        {
            if(order.Id != id || !OrderExists(id)) return BadRequest("can not update order with id: {id}");

            context.Entry(order).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            var order = await context.LogisticsOrders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            context.LogisticsOrders.Remove(order);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool OrderExists(Guid id)
        {
            return context.LogisticsOrders.Any(e => e.Id == id);
        }
    }
}
