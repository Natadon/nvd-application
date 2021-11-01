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
    public class ResultsController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public ResultsController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Results
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> GetResults()
        {
            return await _context.Results.ToListAsync();
        }

        // GET: api/Results/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Result>> GetResult(int id)
        {
            var result = await _context.Results.FindAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // Get api/Results/?{cve_id}
        [Route("[action]/{cve_id}")]
        [HttpGet]
        public Result GetResultByCve(string cve_id)
        {
            var cve_item = _context.Results.SelectMany(result => result.CVE_Items).Where(child => child.cve.CVE_data_meta.ID == cve_id).FirstOrDefault();
            var result = _context.Results
                // include all CVE data
                .Include(r => r.CVE_Items)
                .ThenInclude(c => c.cve)
                .ThenInclude(c => c.CVE_data_meta)
                
                .Include(r => r.CVE_Items)
                .ThenInclude(c => c.cve)
                .ThenInclude(p => p.problemtype)
                .ThenInclude(t => t.problemtype_data)
                .ThenInclude(d => d.description)
                                
                .Include(r => r.CVE_Items)
                .ThenInclude(c => c.cve)
                .ThenInclude(r => r.references)
                .ThenInclude(d => d.reference_data)

                .Include(r => r.CVE_Items)
                .ThenInclude(c => c.cve)
                .ThenInclude(d => d.description)
                .ThenInclude(d => d.description_data)

                // configurations
                .Include(r => r.CVE_Items)
                .ThenInclude(c => c.configurations)
                .ThenInclude(n => n.nodes)
                .ThenInclude(m => m.cpe_match)

                .Include(r => r.CVE_Items)
                .ThenInclude(c => c.impact)
                .ThenInclude(b => b.baseMetricV2)
                .ThenInclude(c => c.cvssV2)

                .Include(r => r.CVE_Items)
                .ThenInclude(c => c.impact)
                .ThenInclude(b => b.baseMetricV3)
                .ThenInclude(c => c.cvssV3)

                .Where(r => r.CVE_Items.Contains(cve_item))                
                .FirstOrDefault();

            return result;
        }

        // PUT: api/Results/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResult(int id, Result result)
        {
            if (id != result.ID)
            {
                return BadRequest();
            }

            _context.Entry(result).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultExists(id))
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

        // POST: api/Results
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Result>> PostResult(Result result)
        {
            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResult", new { id = result.ID }, result);
        }

        // DELETE: api/Results/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            var result = await _context.Results.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Results.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResultExists(int id)
        {
            return _context.Results.Any(e => e.ID == id);
        }
    }
}
