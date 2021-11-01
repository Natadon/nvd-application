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
    public class ConfigurationsController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public ConfigurationsController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/Configurations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Configurations>>> GetConfigurations()
        {
            return await _context.Configurations.ToListAsync();
        }

        // GET: api/Configurations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Configurations>> GetConfigurations(int id)
        {
            var configurations = await _context.Configurations.FindAsync(id);

            if (configurations == null)
            {
                return NotFound();
            }

            return configurations;
        }

        // PUT: api/Configurations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfigurations(int id, Configurations configurations)
        {
            if (id != configurations.ID)
            {
                return BadRequest();
            }

            _context.Entry(configurations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigurationsExists(id))
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

        // POST: api/Configurations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Configurations>> PostConfigurations(Configurations configurations)
        {
            _context.Configurations.Add(configurations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfigurations", new { id = configurations.ID }, configurations);
        }

        // DELETE: api/Configurations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfigurations(int id)
        {
            var configurations = await _context.Configurations.FindAsync(id);
            if (configurations == null)
            {
                return NotFound();
            }

            _context.Configurations.Remove(configurations);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfigurationsExists(int id)
        {
            return _context.Configurations.Any(e => e.ID == id);
        }
    }
}
