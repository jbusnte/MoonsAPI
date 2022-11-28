using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoonsAPI.Models;

namespace MoonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly MoonsAPIDBContext _context;

        public ParentsController(MoonsAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Parents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parent>>> GetParents()
        {
            return await _context.Parents.ToListAsync();
        }

        // GET: api/Parents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parent>> GetParent(int id)
        {
            var parent = await _context.Parents.FindAsync(id);

            if (parent == null)
            {
                return NotFound();
            }

            return parent;
        }
    }
}
