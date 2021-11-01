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
    public class RawDownloadsController : ControllerBase
    {
        private readonly NvdDataContext _context;

        public RawDownloadsController(NvdDataContext context)
        {
            _context = context;
        }

        // GET: api/RawDownloads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RawDownload>>> GetRawDownloads()
        {
            return await _context.RawDownloads.ToListAsync();
        }

        // GET: api/RawDownloads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RawDownload>> GetRawDownload(int id)
        {
            var rawDownload = await _context.RawDownloads.FindAsync(id);

            if (rawDownload == null)
            {
                return NotFound();
            }

            return rawDownload;
        }

        // PUT: api/RawDownloads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRawDownload(int id, RawDownload rawDownload)
        {
            if (id != rawDownload.ID)
            {
                return BadRequest();
            }

            _context.Entry(rawDownload).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RawDownloadExists(id))
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

        // POST: api/RawDownloads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RawDownload>> PostRawDownload(RawDownload rawDownload)
        {
            _context.RawDownloads.Add(rawDownload);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRawDownload", new { id = rawDownload.ID }, rawDownload);
        }

        // DELETE: api/RawDownloads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRawDownload(int id)
        {
            var rawDownload = await _context.RawDownloads.FindAsync(id);
            if (rawDownload == null)
            {
                return NotFound();
            }

            _context.RawDownloads.Remove(rawDownload);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RawDownloadExists(int id)
        {
            return _context.RawDownloads.Any(e => e.ID == id);
        }
    }
}
