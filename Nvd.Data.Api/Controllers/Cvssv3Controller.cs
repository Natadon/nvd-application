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
    public class Cvssv3Controller : ControllerBase
    {
        private readonly NvdDataContext _context;

        public Cvssv3Controller(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Cvssv3
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cvssv3>>> GetCvssv3s()
        {
            return await _context.Cvssv3s.ToListAsync();
        }

        // GET: api/Cvssv3/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cvssv3>> GetCvssv3(int id)
        {
            var cvssv3 = await _context.Cvssv3s.FindAsync(id);

            if (cvssv3 == null)
            {
                return NotFound();
            }

            return cvssv3;
        }

        // PUT: api/Cvssv3/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCvssv3(int id, Cvssv3 cvssv3)
        {
            if (id != cvssv3.ID)
            {
                return BadRequest();
            }

            _context.Entry(cvssv3).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cvssv3Exists(id))
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

        // POST: api/Cvssv3
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cvssv3>> PostCvssv3(Cvssv3 cvssv3)
        {
            _context.Cvssv3s.Add(cvssv3);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCvssv3", new { id = cvssv3.ID }, cvssv3);
        }

        // DELETE: api/Cvssv3/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCvssv3(int id)
        {
            var cvssv3 = await _context.Cvssv3s.FindAsync(id);
            if (cvssv3 == null)
            {
                return NotFound();
            }

            _context.Cvssv3s.Remove(cvssv3);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Cvssv3Exists(int id)
        {
            return _context.Cvssv3s.Any(e => e.ID == id);
        }
    }
}
