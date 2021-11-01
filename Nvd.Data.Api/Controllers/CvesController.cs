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
    public class CvesController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public CvesController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Cves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cve>>> GetCves()
        {
            return await _context.Cves.ToListAsync();
        }

        // GET: api/Cves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cve>> GetCve(int id)
        {
            var cve = await _context.Cves.FindAsync(id);

            if (cve == null)
            {
                return NotFound();
            }

            return cve;
        }

        // PUT: api/Cves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCve(int id, Cve cve)
        {
            if (id != cve.ID)
            {
                return BadRequest();
            }

            _context.Entry(cve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CveExists(id))
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

        // POST: api/Cves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cve>> PostCve(Cve cve)
        {
            _context.Cves.Add(cve);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCve", new { id = cve.ID }, cve);
        }

        // DELETE: api/Cves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCve(int id)
        {
            var cve = await _context.Cves.FindAsync(id);
            if (cve == null)
            {
                return NotFound();
            }

            _context.Cves.Remove(cve);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CveExists(int id)
        {
            return _context.Cves.Any(e => e.ID == id);
        }
    }
}
