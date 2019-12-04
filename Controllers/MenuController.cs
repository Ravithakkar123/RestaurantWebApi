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
    public class MenuController : ControllerBase
    {
        private readonly DataContext _context;

        public MenuController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Menu
        [HttpGet("Getmenu")]
        public async Task<ActionResult<IEnumerable<Menu>>> Getmenu()
        {
            return await _context.menu.ToListAsync();
        }

        // GET: api/Menu/5
        [HttpGet("Getmenu/{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _context.menu.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            return menu;
        }

       
        [HttpPut("PutMenu/{id}")]
        public async Task<IActionResult> PutMenu(int id, Menu menu)
        {
            if (id != menu.MId)
            {
                return BadRequest();
            }

            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
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

        [HttpPost("PostMenu")]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            _context.menu.Add(menu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenu", new { id = menu.MId }, menu);
        }

        // DELETE: api/Menu/5
        [HttpDelete("DeleteMenu/{id}")]
        public async Task<ActionResult<Menu>> DeleteMenu(int id)
        {
            var menu = await _context.menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.menu.Remove(menu);
            await _context.SaveChangesAsync();

            return menu;
        }

        private bool MenuExists(int id)
        {
            return _context.menu.Any(e => e.MId == id);
        }
    }
}
