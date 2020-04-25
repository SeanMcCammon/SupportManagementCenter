using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportManagementCenter.Models
{
    public class EmployeesModel
    {
        [Key] 
        public long EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }
        public string JobTitle { get; set; }
        public string ProductExpertise { get; set; }
    }
}
