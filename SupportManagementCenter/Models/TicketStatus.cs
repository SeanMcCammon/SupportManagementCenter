using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportManagementCenter.Models
{
    public class TicketStatus
    {
        [Key]
        public long StatusId { get; set; }
        [Required]
        public string TicketStatusType { get; set; }
    }
}
