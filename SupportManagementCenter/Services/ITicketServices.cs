using SupportManagementCenter.Models;

namespace SupportManagementCenter.Services
{
    public interface ITicketServices
    {
        long CreateTicket(SupportTicketModel supportTicketModel);
    }
}