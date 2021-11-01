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
    public class Cpe_MatchController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public Cpe_MatchController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Cpe_Match
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cpe_Match>>> GetCpe_Matches()
        {
            return await _context.Cpe_Matches.ToListAsync();
        }

        // GET: api/Cpe_Match/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cpe_Match>> GetCpe_Match(int id)
        {
            var cpe_Match = await _context.Cpe_Matches.FindAsync(id);

            if (cpe_Match == null)
            {
                return NotFound();
            }

            return cpe_Match;
        }

        // PUT: api/Cpe_Match/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCpe_Match(int id, Cpe_Match cpe_Match)
        {
            if (id != cpe_Match.ID)
            {
                return BadRequest();
            }

            _context.Entry(cpe_Match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cpe_MatchExists(id))
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

        // POST: api/Cpe_Match
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cpe_Match>> PostCpe_Match(Cpe_Match cpe_Match)
        {
            _context.Cpe_Matches.Add(cpe_Match);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCpe_Match", new { id = cpe_Match.ID }, cpe_Match);
        }

        // DELETE: api/Cpe_Match/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCpe_Match(int id)
        {
            var cpe_Match = await _context.Cpe_Matches.FindAsync(id);
            if (cpe_Match == null)
            {
                return NotFound();
            }

            _context.Cpe_Matches.Remove(cpe_Match);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Cpe_MatchExists(int id)
        {
            return _context.Cpe_Matches.Any(e => e.ID == id);
        }
    }
}
