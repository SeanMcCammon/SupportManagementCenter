using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportManagementCenter.Models
{
    public class SupportTicketModel
    {
        [Key]
        public long TicketId { get; set; }

        public long AssignedEmployee { get; set; }
        public string TicketTitle { get; set; }
        public string TicketDetails { get; set; }
    }
}
