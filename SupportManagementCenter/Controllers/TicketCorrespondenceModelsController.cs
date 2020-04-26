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
    public class TicketCorrespondenceModelsController : ControllerBase
    {
        private readonly SupportManagementCenterDBContext _context;

        public TicketCorrespondenceModelsController(SupportManagementCenterDBContext context)
        {
            _context = context;
        }

        // GET: api/TicketCorrespondenceModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketCorrespondenceModel>>> GetTicketCorrespondenceModel()
        {
            return await _context.TicketCorrespondenceModel.ToListAsync();
        }

        // GET: api/TicketCorrespondenceModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketCorrespondenceModel>> GetTicketCorrespondenceModel(long id)
        {
            var ticketCorrespondenceModel = await _context.TicketCorrespondenceModel.FindAsync(id);

            if (ticketCorrespondenceModel == null)
            {
                return NotFound();
            }

            return ticketCorrespondenceModel;
        }

        // PUT: api/TicketCorrespondenceModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketCorrespondenceModel(long id, TicketCorrespondenceModel ticketCorrespondenceModel)
        {
            if (id != ticketCorrespondenceModel.CorrispondenceId)
            {
                return BadRequest();
            }

            _context.Entry(ticketCorrespondenceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketCorrespondenceModelExists(id))
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

        // POST: api/TicketCorrespondenceModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TicketCorrespondenceModel>> PostTicketCorrespondenceModel(TicketCorrespondenceModel ticketCorrespondenceModel)
        {
            _context.TicketCorrespondenceModel.Add(ticketCorrespondenceModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketCorrespondenceModel", new { id = ticketCorrespondenceModel.CorrispondenceId }, ticketCorrespondenceModel);
        }

        // DELETE: api/TicketCorrespondenceModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TicketCorrespondenceModel>> DeleteTicketCorrespondenceModel(long id)
        {
            var ticketCorrespondenceModel = await _context.TicketCorrespondenceModel.FindAsync(id);
            if (ticketCorrespondenceModel == null)
            {
                return NotFound();
            }

            _context.TicketCorrespondenceModel.Remove(ticketCorrespondenceModel);
            await _context.SaveChangesAsync();

            return ticketCorrespondenceModel;
        }

        private bool TicketCorrespondenceModelExists(long id)
        {
            return _context.TicketCorrespondenceModel.Any(e => e.CorrispondenceId == id);
        }
    }
}
