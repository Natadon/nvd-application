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
    public class Reference_DataController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public Reference_DataController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Reference_Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reference_Data>>> GetReference_Data()
        {
            return await _context.Reference_Data.ToListAsync();
        }

        // GET: api/Reference_Data/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reference_Data>> GetReference_Data(int id)
        {
            var reference_Data = await _context.Reference_Data.FindAsync(id);

            if (reference_Data == null)
            {
                return NotFound();
            }

            return reference_Data;
        }

        // PUT: api/Reference_Data/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReference_Data(int id, Reference_Data reference_Data)
        {
            if (id != reference_Data.ID)
            {
                return BadRequest();
            }

            _context.Entry(reference_Data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Reference_DataExists(id))
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

        // POST: api/Reference_Data
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reference_Data>> PostReference_Data(Reference_Data reference_Data)
        {
            _context.Reference_Data.Add(reference_Data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReference_Data", new { id = reference_Data.ID }, reference_Data);
        }

        // DELETE: api/Reference_Data/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReference_Data(int id)
        {
            var reference_Data = await _context.Reference_Data.FindAsync(id);
            if (reference_Data == null)
            {
                return NotFound();
            }

            _context.Reference_Data.Remove(reference_Data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Reference_DataExists(int id)
        {
            return _context.Reference_Data.Any(e => e.ID == id);
        }
    }
}
