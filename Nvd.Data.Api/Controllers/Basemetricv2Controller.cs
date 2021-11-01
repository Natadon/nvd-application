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
    public class Basemetricv2Controller : ControllerBase
    {
        private readonly NvdDataContext _context;

        public Basemetricv2Controller(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Basemetricv2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Basemetricv2>>> GetBaseMetricsV2()
        {
            return await _context.BaseMetricsV2.ToListAsync();
        }

        // GET: api/Basemetricv2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Basemetricv2>> GetBasemetricv2(int id)
        {
            var basemetricv2 = await _context.BaseMetricsV2.FindAsync(id);

            if (basemetricv2 == null)
            {
                return NotFound();
            }

            return basemetricv2;
        }

        // PUT: api/Basemetricv2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasemetricv2(int id, Basemetricv2 basemetricv2)
        {
            if (id != basemetricv2.ID)
            {
                return BadRequest();
            }

            _context.Entry(basemetricv2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Basemetricv2Exists(id))
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

        // POST: api/Basemetricv2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Basemetricv2>> PostBasemetricv2(Basemetricv2 basemetricv2)
        {
            _context.BaseMetricsV2.Add(basemetricv2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasemetricv2", new { id = basemetricv2.ID }, basemetricv2);
        }

        // DELETE: api/Basemetricv2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasemetricv2(int id)
        {
            var basemetricv2 = await _context.BaseMetricsV2.FindAsync(id);
            if (basemetricv2 == null)
            {
                return NotFound();
            }

            _context.BaseMetricsV2.Remove(basemetricv2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Basemetricv2Exists(int id)
        {
            return _context.BaseMetricsV2.Any(e => e.ID == id);
        }
    }
}
