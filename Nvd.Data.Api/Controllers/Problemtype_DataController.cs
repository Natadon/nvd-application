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
    public class Problemtype_DataController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public Problemtype_DataController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Problemtype_Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Problemtype_Data>>> GetProblemtype_Data()
        {
            return await _context.Problemtype_Data.ToListAsync();
        }

        // GET: api/Problemtype_Data/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Problemtype_Data>> GetProblemtype_Data(int id)
        {
            var problemtype_Data = await _context.Problemtype_Data.FindAsync(id);

            if (problemtype_Data == null)
            {
                return NotFound();
            }

            return problemtype_Data;
        }

        // PUT: api/Problemtype_Data/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProblemtype_Data(int id, Problemtype_Data problemtype_Data)
        {
            if (id != problemtype_Data.ID)
            {
                return BadRequest();
            }

            _context.Entry(problemtype_Data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Problemtype_DataExists(id))
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

        // POST: api/Problemtype_Data
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Problemtype_Data>> PostProblemtype_Data(Problemtype_Data problemtype_Data)
        {
            _context.Problemtype_Data.Add(problemtype_Data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProblemtype_Data", new { id = problemtype_Data.ID }, problemtype_Data);
        }

        // DELETE: api/Problemtype_Data/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProblemtype_Data(int id)
        {
            var problemtype_Data = await _context.Problemtype_Data.FindAsync(id);
            if (problemtype_Data == null)
            {
                return NotFound();
            }

            _context.Problemtype_Data.Remove(problemtype_Data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Problemtype_DataExists(int id)
        {
            return _context.Problemtype_Data.Any(e => e.ID == id);
        }
    }
}
