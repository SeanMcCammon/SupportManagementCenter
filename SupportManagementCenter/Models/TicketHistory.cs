using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportManagementCenter.Models
{
    public class TicketHistory
    {
        [Key]
        public long TicketHistoryId { get; set; }
        [Required]
        public long EmployeeId { get; set; }

        public DateTime StatusUpdateDate { get; set; }
        public string StatusUpdateTitle { get; set; }
        public string StatusUpdateDetails { get; set; }
    }
}
