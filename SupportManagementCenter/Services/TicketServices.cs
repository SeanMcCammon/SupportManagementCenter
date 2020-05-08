using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportManagementCenter.Models;

namespace SupportManagementCenter.Services
{
    public class TicketServices : ITicketServices
    {
        private readonly SupportManagementCenterDBContext _context;

        public TicketServices(SupportManagementCenterDBContext context)
        {
            _context = context;
        }
        public long CreateTicket(SupportTicketModel supportTicketModel)
        {
            // Add date ticket raised before write to DB
            supportTicketModel.DateRaised = DateTime.Now;

            _context.Add(supportTicketModel);
            _context.SaveChanges();

            return supportTicketModel.TicketId;
        }
    }
}
