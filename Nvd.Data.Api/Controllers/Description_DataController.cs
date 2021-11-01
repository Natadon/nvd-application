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
    public class Description_DataController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public Description_DataController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Description_Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Description_Data>>> GetDescription_Data()
        {
            return await _context.Description_Data.ToListAsync();
        }

        // GET: api/Description_Data/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Description_Data>> GetDescription_Data(int id)
        {
            var description_Data = await _context.Description_Data.FindAsync(id);

            if (description_Data == null)
            {
                return NotFound();
            }

            return description_Data;
        }

        // PUT: api/Description_Data/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescription_Data(int id, Description_Data description_Data)
        {
            if (id != description_Data.ID)
            {
                return BadRequest();
            }

            _context.Entry(description_Data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Description_DataExists(id))
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

        // POST: api/Description_Data
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Description_Data>> PostDescription_Data(Description_Data description_Data)
        {
            _context.Description_Data.Add(description_Data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDescription_Data", new { id = description_Data.ID }, description_Data);
        }

        // DELETE: api/Description_Data/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescription_Data(int id)
        {
            var description_Data = await _context.Description_Data.FindAsync(id);
            if (description_Data == null)
            {
                return NotFound();
            }

            _context.Description_Data.Remove(description_Data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Description_DataExists(int id)
        {
            return _context.Description_Data.Any(e => e.ID == id);
        }
    }
}
