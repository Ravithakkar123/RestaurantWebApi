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
    public class ItemDataController : ControllerBase
    {
        private readonly DataContext _context;

        public ItemDataController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ItemData
        [HttpGet("GetItemData")]
        public async Task<ActionResult<IEnumerable<ItemData>>> GetItemData()
        {
            return await _context.ItemData.ToListAsync();
        }

        // GET: api/ItemData/5
        [HttpGet("GetItemData/{id}")]
        public async Task<ActionResult<ItemData>> GetItemData(int id)
        {
            var itemData = await _context.ItemData.FindAsync(id);

            if (itemData == null)
            {
                return NotFound();
            }

            return itemData;
        }

        // PUT: api/ItemData/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("PutItemData/{id}")]
        public async Task<IActionResult> PutItemData(int id, ItemData itemData)
        {
            if (id != itemData.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(itemData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemDataExists(id))
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

        [HttpPost("PostItemData")]
        public async Task<ActionResult<ItemData>> PostItemData(ItemData itemData)
        {
            _context.ItemData.Add(itemData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemData", new { id = itemData.ItemId }, itemData);
        }

        // DELETE: api/ItemData/5
        [HttpDelete("DeleteItemData/{id}")]
        public async Task<ActionResult<ItemData>> DeleteItemData(int id)
        {
            var itemData = await _context.ItemData.FindAsync(id);
            if (itemData == null)
            {
                return NotFound();
            }

            _context.ItemData.Remove(itemData);
            await _context.SaveChangesAsync();

            return itemData;
        }

        private bool ItemDataExists(int id)
        {
            return _context.ItemData.Any(e => e.ItemId == id);
        }
    }
}
