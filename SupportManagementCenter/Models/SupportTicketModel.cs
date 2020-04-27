using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SupportManagementCenter.Models
{
    public class SupportTicketModel
    {
        [Key]
        public long TicketId { get; set; }

        public long ProductId { get; set; }

        public long AssignedEmployeeId { get; set; }
        [Required]
        public string TicketTitle { get; set; }
        [Required]
        public string TicketDetails { get; set; }
        public DateTime DateRaised { get; set; }
        public DateTime DateClosed { get; set; }
        public string CustomerName { get; set; }
        public long CustomerId { get; set; }
        [Required]
        public string CustomerEmail { get; set; }

        public DbSet<TicketCorrespondenceModel> TicketCorrispondense { get; set; }
        public DbSet<TicketHistory> TicketHistoryHistories { get; set; }
    }
}
