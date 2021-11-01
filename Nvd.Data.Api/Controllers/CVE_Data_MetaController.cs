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
    public class CVE_Data_MetaController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public CVE_Data_MetaController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/CVE_Data_Meta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CVE_Data_Meta>>> GetCVE_Data_Metas()
        {
            return await _context.CVE_Data_Metas.ToListAsync();
        }

        // GET: api/CVE_Data_Meta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CVE_Data_Meta>> GetCVE_Data_Meta(int id)
        {
            var cVE_Data_Meta = await _context.CVE_Data_Metas.FindAsync(id);

            if (cVE_Data_Meta == null)
            {
                return NotFound();
            }

            return cVE_Data_Meta;
        }

        // PUT: api/CVE_Data_Meta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCVE_Data_Meta(int id, CVE_Data_Meta cVE_Data_Meta)
        {
            if (id != cVE_Data_Meta.PrimaryKey)
            {
                return BadRequest();
            }

            _context.Entry(cVE_Data_Meta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CVE_Data_MetaExists(id))
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

        // POST: api/CVE_Data_Meta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CVE_Data_Meta>> PostCVE_Data_Meta(CVE_Data_Meta cVE_Data_Meta)
        {
            _context.CVE_Data_Metas.Add(cVE_Data_Meta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCVE_Data_Meta", new { id = cVE_Data_Meta.PrimaryKey }, cVE_Data_Meta);
        }

        // DELETE: api/CVE_Data_Meta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCVE_Data_Meta(int id)
        {
            var cVE_Data_Meta = await _context.CVE_Data_Metas.FindAsync(id);
            if (cVE_Data_Meta == null)
            {
                return NotFound();
            }

            _context.CVE_Data_Metas.Remove(cVE_Data_Meta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CVE_Data_MetaExists(int id)
        {
            return _context.CVE_Data_Metas.Any(e => e.PrimaryKey == id);
        }
    }
}
