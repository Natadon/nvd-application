using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nvd.DataAccess;
using Nvd.DataAccess.Objects;

namespace Nvd.Data.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Basemetricv3Controller : ControllerBase
    {
        private readonly NvdDataContext _context;

        public Basemetricv3Controller(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Basemetricv3
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Basemetricv3>>> GetBaseMetricsV3()
        {
            return await _context.BaseMetricsV3.ToListAsync();
        }

        // GET: api/Basemetricv3/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Basemetricv3>> GetBasemetricv3(int id)
        {
            var basemetricv3 = await _context.BaseMetricsV3.FindAsync(id);

            if (basemetricv3 == null)
            {
                return NotFound();
            }

            return basemetricv3;
        }

        // PUT: api/Basemetricv3/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasemetricv3(int id, Basemetricv3 basemetricv3)
        {
            if (id != basemetricv3.ID)
            {
                return BadRequest();
            }

            _context.Entry(basemetricv3).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Basemetricv3Exists(id))
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

        // POST: api/Basemetricv3
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Basemetricv3>> PostBasemetricv3(Basemetricv3 basemetricv3)
        {
            _context.BaseMetricsV3.Add(basemetricv3);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasemetricv3", new { id = basemetricv3.ID }, basemetricv3);
        }

        // DELETE: api/Basemetricv3/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasemetricv3(int id)
        {
            var basemetricv3 = await _context.BaseMetricsV3.FindAsync(id);
            if (basemetricv3 == null)
            {
                return NotFound();
            }

            _context.BaseMetricsV3.Remove(basemetricv3);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Basemetricv3Exists(int id)
        {
            return _context.BaseMetricsV3.Any(e => e.ID == id);
        }
    }
}
