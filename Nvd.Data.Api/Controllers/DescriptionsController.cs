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
    public class DescriptionsController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public DescriptionsController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Descriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Description>>> GetDescriptions()
        {
            return await _context.Descriptions.ToListAsync();
        }

        // GET: api/Descriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Description>> GetDescription(int id)
        {
            var description = await _context.Descriptions.FindAsync(id);

            if (description == null)
            {
                return NotFound();
            }

            return description;
        }

        // PUT: api/Descriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescription(int id, Description description)
        {
            if (id != description.ID)
            {
                return BadRequest();
            }

            _context.Entry(description).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptionExists(id))
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

        // POST: api/Descriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Description>> PostDescription(Description description)
        {
            _context.Descriptions.Add(description);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDescription", new { id = description.ID }, description);
        }

        // DELETE: api/Descriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescription(int id)
        {
            var description = await _context.Descriptions.FindAsync(id);
            if (description == null)
            {
                return NotFound();
            }

            _context.Descriptions.Remove(description);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DescriptionExists(int id)
        {
            return _context.Descriptions.Any(e => e.ID == id);
        }
    }
}
