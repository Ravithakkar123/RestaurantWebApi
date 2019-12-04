using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;

namespace RestaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDataController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderDataController(DataContext context)
        {
            _context = context;
        }

        // GET: api/OrderData
        [HttpGet("GetorderData")]
        public async Task<ActionResult<IEnumerable<OrderData>>> GetorderData()
        {
            return await _context.orderData.ToListAsync();
        }

        // GET: api/OrderData/5
        [HttpGet("GetorderData/{id}")]
        public async Task<ActionResult<OrderData>> GetOrderData(int id)
        {
            var orderData = await _context.orderData.FindAsync(id);

            if (orderData == null)
            {
                return NotFound();
            }

            return orderData;
        }
        
        [HttpPut("PutOrderData/{id}")]
        public async Task<IActionResult> PutOrderData(int id, OrderData orderData)
        {
            if (id != orderData.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       
        [HttpPost("PostOrderData")]
        public async Task<ActionResult<OrderData>> PostOrderData(OrderData orderData)
        {
            _context.orderData.Add(orderData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderData", new { id = orderData.OrderId }, orderData);
        }

        // DELETE: api/OrderData/5
        [HttpDelete("DeleteOrderData/{id}")]
        public async Task<ActionResult<OrderData>> DeleteOrderData(int id)
        {
            var orderData = await _context.orderData.FindAsync(id);
            if (orderData == null)
            {
                return NotFound();
            }

            _context.orderData.Remove(orderData);
            await _context.SaveChangesAsync();

            return orderData;
        }

        private bool OrderDataExists(int id)
        {
            return _context.orderData.Any(e => e.OrderId == id);
        }
    }
}
