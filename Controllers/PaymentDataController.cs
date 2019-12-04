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
    public class PaymentDataController : ControllerBase
    {
        private readonly DataContext _context;

        public PaymentDataController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PaymentData
        [HttpGet("GetPaymentData")]
        public async Task<ActionResult<IEnumerable<PaymentData>>> GetpaymentData()
        {

            return await _context.paymentDatas.ToListAsync();
        }

        // GET: api/PaymentData/5
        [HttpGet("GetPaymentData/{id}")]
        public async Task<ActionResult<PaymentData>> GetPaymentData(int id)
        {
            try
            {
                var paymentData = await _context.paymentDatas.FindAsync(id);
                return paymentData;
            }
            catch
            { 
           
            
                return BadRequest();
            }

            
        }

        // PUT: api/PaymentData/5

        [HttpPut("PutPaymentData/{id}")]
        public async Task<IActionResult> PutPaymentData(int id, PaymentData paymentData)
        {
            if (id != paymentData.PId)
            {
                return BadRequest();
            }

            _context.Entry(paymentData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDataExists(id))
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

        // POST: api/PaymentData
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("PostPaymentData")]
        public async Task<ActionResult<PaymentData>> PostPaymentData(PaymentData paymentData)
        {
            _context.paymentDatas.Add(paymentData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentData", new { id = paymentData.PId }, paymentData);
        }

        // DELETE: api/PaymentData/5
        [HttpDelete("DeletePaymentData/{id}")]
        public async Task<ActionResult<PaymentData>> DeletePaymentData(int id)
        {
            var paymentData = await _context.paymentDatas.FindAsync(id);
            if (paymentData == null)
            {
                return NotFound();
            }

            _context.paymentDatas.Remove(paymentData);
            await _context.SaveChangesAsync();

            return paymentData;
        }

        private bool PaymentDataExists(int id)
        {
            return _context.paymentDatas.Any(e => e.PId == id);
        }
    }
}
