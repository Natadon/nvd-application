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
    public class Description1Controller : ControllerBase
    {
        private readonly NvdDataContext _context;

        public Description1Controller(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Description1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Description1>>> GetDescription1()
        {
            return await _context.Description1.ToListAsync();
        }

        // GET: api/Description1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Description1>> GetDescription1(int id)
        {
            var description1 = await _context.Description1.FindAsync(id);

            if (description1 == null)
            {
                return NotFound();
            }

            return description1;
        }

        // PUT: api/Description1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescription1(int id, Description1 description1)
        {
            if (id != description1.ID)
            {
                return BadRequest();
            }

            _context.Entry(description1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Description1Exists(id))
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

        // POST: api/Description1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Description1>> PostDescription1(Description1 description1)
        {
            _context.Description1.Add(description1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDescription1", new { id = description1.ID }, description1);
        }

        // DELETE: api/Description1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescription1(int id)
        {
            var description1 = await _context.Description1.FindAsync(id);
            if (description1 == null)
            {
                return NotFound();
            }

            _context.Description1.Remove(description1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Description1Exists(int id)
        {
            return _context.Description1.Any(e => e.ID == id);
        }
    }
}
