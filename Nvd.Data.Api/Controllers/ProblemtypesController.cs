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
    public class ProblemtypesController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public ProblemtypesController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Problemtypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Problemtype>>> GetProblemTypes()
        {
            return await _context.ProblemTypes.ToListAsync();
        }

        // GET: api/Problemtypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Problemtype>> GetProblemtype(int id)
        {
            var problemtype = await _context.ProblemTypes.FindAsync(id);

            if (problemtype == null)
            {
                return NotFound();
            }

            return problemtype;
        }

        // PUT: api/Problemtypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProblemtype(int id, Problemtype problemtype)
        {
            if (id != problemtype.ID)
            {
                return BadRequest();
            }

            _context.Entry(problemtype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProblemtypeExists(id))
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

        // POST: api/Problemtypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Problemtype>> PostProblemtype(Problemtype problemtype)
        {
            _context.ProblemTypes.Add(problemtype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProblemtype", new { id = problemtype.ID }, problemtype);
        }

        // DELETE: api/Problemtypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProblemtype(int id)
        {
            var problemtype = await _context.ProblemTypes.FindAsync(id);
            if (problemtype == null)
            {
                return NotFound();
            }

            _context.ProblemTypes.Remove(problemtype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProblemtypeExists(int id)
        {
            return _context.ProblemTypes.Any(e => e.ID == id);
        }
    }
}
