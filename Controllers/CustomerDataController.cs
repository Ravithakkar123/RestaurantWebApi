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
    public class CustomerDataController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerDataController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CustomerData
        [HttpGet("GetcustomerData")]
        public async Task<ActionResult<IEnumerable<CustomerData>>> GetcustomerData()
        {
            return await _context.customerData.ToListAsync();
        }

        // GET: api/CustomerData/5
        [HttpGet("GetcustomerData/{id}")]
        public async Task<ActionResult<CustomerData>> GetCustomerData(int id)
        {
            var customerData = await _context.customerData.FindAsync(id);

            if (customerData == null)
            {
                return NotFound();
            }

            return customerData;
        }

        
        [HttpPut("GetcustomerData/{id}")]
        public async Task<IActionResult> PutCustomerData(int id, CustomerData customerData)
        {
            if (id != customerData.CId)
            {
                return BadRequest();
            }

            _context.Entry(customerData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDataExists(id))
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

        
        [HttpPost("PostCustomerData")]
        public async Task<ActionResult<CustomerData>> PostCustomerData(CustomerData customerData)
        {
            _context.customerData.Add(customerData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerData", new { id = customerData.CId }, customerData);
        }

        // DELETE: api/CustomerData/5
        [HttpDelete("DeleteCustomerData/{id}")]
        public async Task<ActionResult<CustomerData>> DeleteCustomerData(int id)
        {
            var customerData = await _context.customerData.FindAsync(id);
            if (customerData == null)
            {
                return NotFound();
            }

            _context.customerData.Remove(customerData);
            await _context.SaveChangesAsync();

            return customerData;
        }

        private bool CustomerDataExists(int id)
        {
            return _context.customerData.Any(e => e.CId == id);
        }
    }
}
