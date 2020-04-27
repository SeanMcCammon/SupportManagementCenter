using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportManagementCenter.Models;

namespace SupportManagementCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketStatusController : ControllerBase
    {
        private readonly SupportManagementCenterDBContext _context;

        public TicketStatusController(SupportManagementCenterDBContext context)
        {
            _context = context;
        }

        // GET: api/TicketStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketStatus>>> GetTicketStatus()
        {
            return await _context.TicketStatus.ToListAsync();
        }

        // GET: api/TicketStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketStatus>> GetTicketStatus(long id)
        {
            var ticketStatus = await _context.TicketStatus.FindAsync(id);

            if (ticketStatus == null)
            {
                return NotFound();
            }

            return ticketStatus;
        }

        // PUT: api/TicketStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketStatus(long id, TicketStatus ticketStatus)
        {
            if (id != ticketStatus.StatusId)
            {
                return BadRequest();
            }

            _context.Entry(ticketStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketStatusExists(id))
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

        // POST: api/TicketStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TicketStatus>> PostTicketStatus(TicketStatus ticketStatus)
        {
            _context.TicketStatus.Add(ticketStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketStatus", new { id = ticketStatus.StatusId }, ticketStatus);
        }

        // DELETE: api/TicketStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TicketStatus>> DeleteTicketStatus(long id)
        {
            var ticketStatus = await _context.TicketStatus.FindAsync(id);
            if (ticketStatus == null)
            {
                return NotFound();
            }

            _context.TicketStatus.Remove(ticketStatus);
            await _context.SaveChangesAsync();

            return ticketStatus;
        }

        private bool TicketStatusExists(long id)
        {
            return _context.TicketStatus.Any(e => e.StatusId == id);
        }
    }
}
