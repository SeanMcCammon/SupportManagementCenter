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

        //public long AssignedEmployee { get; set; }
        public string TicketTitle { get; set; }
        public string TicketDetails { get; set; }
        public DateTime DateRaised { get; set; }
        public DateTime DateClosed { get; set; }
        //public long Corrispondance { get; set; }
        public string CustomerName { get; set; }
        public long CustomerId { get; set; }
        public string CustomerEmail { get; set; }

        private DbSet<TicketCorrespondenceModel> TicketCorrispondense;

        public DbSet<EmployeesModel> AssignedEmployee { get; set; }
        public DbSet<ProductsModel> ProductsId { get; set; }
    }
}
