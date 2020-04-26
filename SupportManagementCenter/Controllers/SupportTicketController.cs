using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupportManagementCenter.Models;

namespace SupportManagementCenter.Controllers
{
    public class SupportTicketController : Controller
    {
        private readonly SupportManagementCenterDBContext _context;

        public SupportTicketController(SupportManagementCenterDBContext context)
        {
            _context = context;
        }

        // GET: SupportTicketModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.supportTickets.ToListAsync());
        }

        // GET: SupportTicketModels/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportTicketModel = await _context.supportTickets
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (supportTicketModel == null)
            {
                return NotFound();
            }

            return View(supportTicketModel);
        }

        // GET: SupportTicketModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupportTicketModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,ProductId,AssignedEmployeeId,TicketTitle,TicketDetails,DateRaised,DateClosed,CustomerName,CustomerId,CustomerEmail")] SupportTicketModel supportTicketModel)
        {
            if (ModelState.IsValid)
            {
                // Add date ticket raised before write to DB
                supportTicketModel.DateRaised = DateTime.Now;

                _context.Add(supportTicketModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supportTicketModel);
        }

        // GET: SupportTicketModels/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportTicketModel = await _context.supportTickets.FindAsync(id);
            if (supportTicketModel == null)
            {
                return NotFound();
            }
            return View(supportTicketModel);
        }

        // POST: SupportTicketModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("TicketId,ProductId,AssignedEmployeeId,TicketTitle,TicketDetails,DateRaised,DateClosed,CustomerName,CustomerId,CustomerEmail")] SupportTicketModel supportTicketModel)
        {
            if (id != supportTicketModel.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportTicketModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportTicketModelExists(supportTicketModel.TicketId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supportTicketModel);
        }

        // GET: SupportTicketModels/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportTicketModel = await _context.supportTickets
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (supportTicketModel == null)
            {
                return NotFound();
            }

            return View(supportTicketModel);
        }

        // POST: SupportTicketModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var supportTicketModel = await _context.supportTickets.FindAsync(id);
            _context.supportTickets.Remove(supportTicketModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportTicketModelExists(long id)
        {
            return _context.supportTickets.Any(e => e.TicketId == id);
        }
    }
}
