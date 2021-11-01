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
    public class Cvssv2Controller : ControllerBase
    {
        private readonly NvdDataContext _context;

        public Cvssv2Controller(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Cvssv2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cvssv2>>> GetCvssv2s()
        {
            return await _context.Cvssv2s.ToListAsync();
        }

        // GET: api/Cvssv2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cvssv2>> GetCvssv2(int id)
        {
            var cvssv2 = await _context.Cvssv2s.FindAsync(id);

            if (cvssv2 == null)
            {
                return NotFound();
            }

            return cvssv2;
        }

        // PUT: api/Cvssv2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCvssv2(int id, Cvssv2 cvssv2)
        {
            if (id != cvssv2.ID)
            {
                return BadRequest();
            }

            _context.Entry(cvssv2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cvssv2Exists(id))
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

        // POST: api/Cvssv2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cvssv2>> PostCvssv2(Cvssv2 cvssv2)
        {
            _context.Cvssv2s.Add(cvssv2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCvssv2", new { id = cvssv2.ID }, cvssv2);
        }

        // DELETE: api/Cvssv2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCvssv2(int id)
        {
            var cvssv2 = await _context.Cvssv2s.FindAsync(id);
            if (cvssv2 == null)
            {
                return NotFound();
            }

            _context.Cvssv2s.Remove(cvssv2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Cvssv2Exists(int id)
        {
            return _context.Cvssv2s.Any(e => e.ID == id);
        }
    }
}
