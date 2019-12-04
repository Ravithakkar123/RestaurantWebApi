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
    public class OrderItemDataController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderItemDataController(DataContext context)
        {
            _context = context;
        }

       
        

        // GET: api/OrderItemData
       [HttpGet("GetorderItemData")]
        public async Task<ActionResult<IEnumerable<OrderItemData>>> GetorderItemData()
        {
            try
            {
                var orderItemData =await _context.orderItemData.ToListAsync();
                return Ok(orderItemData);
            }
            catch
            {
                return BadRequest();
            }

        }

        // GET: api/OrderItemData/5
        [HttpGet("GetorderItemData/{id}")]
        public async Task<ActionResult<OrderItemData>> GetOrderItemData(int id)
        {
            try
            {
                var orderItemData = await _context.orderItemData.FindAsync(id);
                return Ok(orderItemData);

            }
            catch
            {
                return BadRequest();
            }
        }
        
        // PUT: api/OrderItemData/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("PutOrderItemData/{id}")]
        public async Task<IActionResult> PutOrderItemData(int id, OrderItemData orderItemData)
        {
            if (id != orderItemData.OrderItemId)
            {
                return BadRequest();
            }

            _context.Entry(orderItemData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(orderItemData);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            
        }

        
        [HttpPost("PostOrderItemData")]
        public async Task<ActionResult<OrderItemData>> PostOrderItemData(OrderItemData orderItemData)
        {
            try
            {
                _context.orderItemData.Add(orderItemData);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetOrderItemData", new { id = orderItemData.OrderItemId }, orderItemData);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/OrderItemData/5
        [HttpDelete("DeleteOrderItemData/{id}")]
        public async Task<ActionResult<OrderItemData>> DeleteOrderItemData(int id)
        {
            var orderItemData = await _context.orderItemData.FindAsync(id);
            if (orderItemData == null)
            {
                return NotFound();
            }

            _context.orderItemData.Remove(orderItemData);
            try
            {
                await _context.SaveChangesAsync();
                return orderItemData;
            }
            catch
            {
                return BadRequest();
            }
        }

        private bool OrderItemDataExists(int id)
        {
            return _context.orderItemData.Any(e => e.OrderItemId == id);
        }
    }
}
