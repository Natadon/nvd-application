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
    public class CVE_ItemsController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public CVE_ItemsController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/CVE_Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CVE_Items>>> GetCVE_Items()
        {
            return await _context.CVE_Items.ToListAsync();
        }

        // GET: api/CVE_Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CVE_Items>> GetCVE_Items(int id)
        {
            var cVE_Items = await _context.CVE_Items.FindAsync(id);

            if (cVE_Items == null)
            {
                return NotFound();
            }

            return cVE_Items;
        }

        // PUT: api/CVE_Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCVE_Items(int id, CVE_Items cVE_Items)
        {
            if (id != cVE_Items.ID)
            {
                return BadRequest();
            }

            _context.Entry(cVE_Items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CVE_ItemsExists(id))
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

        // POST: api/CVE_Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CVE_Items>> PostCVE_Items(CVE_Items cVE_Items)
        {
            _context.CVE_Items.Add(cVE_Items);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCVE_Items", new { id = cVE_Items.ID }, cVE_Items);
        }

        // DELETE: api/CVE_Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCVE_Items(int id)
        {
            var cVE_Items = await _context.CVE_Items.FindAsync(id);
            if (cVE_Items == null)
            {
                return NotFound();
            }

            _context.CVE_Items.Remove(cVE_Items);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CVE_ItemsExists(int id)
        {
            return _context.CVE_Items.Any(e => e.ID == id);
        }
    }
}
