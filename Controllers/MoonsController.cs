using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoonsAPI.Models;
using System.Net;

namespace MoonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoonsController : ControllerBase
    {
        private readonly MoonsAPIDBContext _context;

        public MoonsController(MoonsAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Moons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moon>>> GetMoons()
        {
            return await _context.Moons.Include((p) => p.Parent).ToListAsync();
        }

        // GET: api/Moons/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Moon>> GetMoon(int id)
        {
            var moon = await _context.Moons.Include((p) => p.Parent).FirstOrDefaultAsync(p => p.MoonId == id);

            if (moon == null)
            {
                return NotFound();
            }

            return moon;
        }

        // GET: api/Moons/parent
        [HttpGet("{parent}")]
        public async Task<ActionResult<IEnumerable<Moon>>> GetMoonsFromParent(string parent)
        {
            return await _context.Moons.Include((p) => p.Parent).Where(p => p.Parent.ParentName == parent).ToListAsync();
        }

        // POST: api/Moons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Moon>> PostMoon(Moon moon)
        {
            _context.Moons.Add(moon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoon", new { id = moon.MoonId }, moon);
        }

        // DELETE: api/Moons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoon(int id)
        {
            var moon = await _context.Moons.FindAsync(id);
            if (moon == null)
            {
                return NotFound();
            }

            _context.Moons.Remove(moon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoonExists(int id)
        {
            return _context.Moons.Any(e => e.MoonId == id);
        }
    }
}
