using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportManagementCenter.Models
{
    public class TicketCorrespondenceModel
    {
        [Key]
        public long CorrispondenceId { get; set; }

        [Required]
        public long TicketId { get; set; }
        [Required] 
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public long EmployeeId { get; set; }
        public long CustomerId { get; set; }
    }
}
