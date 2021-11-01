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
    public class NvdSearchResultsController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public NvdSearchResultsController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/NvdSearchResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NvdSearchResult>>> GetNvdSearchResults()
        {
            return await _context.NvdSearchResults.ToListAsync();
        }

        // GET: api/NvdSearchResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NvdSearchResult>> GetNvdSearchResult(int id)
        {
            var nvdSearchResult = await _context.NvdSearchResults.FindAsync(id);

            if (nvdSearchResult == null)
            {
                return NotFound();
            }

            return nvdSearchResult;
        }

        // PUT: api/NvdSearchResults/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNvdSearchResult(int id, NvdSearchResult nvdSearchResult)
        {
            if (id != nvdSearchResult.ID)
            {
                return BadRequest();
            }

            _context.Entry(nvdSearchResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NvdSearchResultExists(id))
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

        // POST: api/NvdSearchResults
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NvdSearchResult>> PostNvdSearchResult(NvdSearchResult nvdSearchResult)
        {
            _context.NvdSearchResults.Add(nvdSearchResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNvdSearchResult", new { id = nvdSearchResult.ID }, nvdSearchResult);
        }

        // DELETE: api/NvdSearchResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNvdSearchResult(int id)
        {
            var nvdSearchResult = await _context.NvdSearchResults.FindAsync(id);
            if (nvdSearchResult == null)
            {
                return NotFound();
            }

            _context.NvdSearchResults.Remove(nvdSearchResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NvdSearchResultExists(int id)
        {
            return _context.NvdSearchResults.Any(e => e.ID == id);
        }
    }
}
