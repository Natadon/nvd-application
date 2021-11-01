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
    public class ImpactsController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public ImpactsController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Impacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Impact>>> GetImpacts()
        {
            return await _context.Impacts.ToListAsync();
        }

        // GET: api/Impacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Impact>> GetImpact(int id)
        {
            var impact = await _context.Impacts.FindAsync(id);

            if (impact == null)
            {
                return NotFound();
            }

            return impact;
        }

        // PUT: api/Impacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImpact(int id, Impact impact)
        {
            if (id != impact.ID)
            {
                return BadRequest();
            }

            _context.Entry(impact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImpactExists(id))
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

        // POST: api/Impacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Impact>> PostImpact(Impact impact)
        {
            _context.Impacts.Add(impact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImpact", new { id = impact.ID }, impact);
        }

        // DELETE: api/Impacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImpact(int id)
        {
            var impact = await _context.Impacts.FindAsync(id);
            if (impact == null)
            {
                return NotFound();
            }

            _context.Impacts.Remove(impact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImpactExists(int id)
        {
            return _context.Impacts.Any(e => e.ID == id);
        }
    }
}
