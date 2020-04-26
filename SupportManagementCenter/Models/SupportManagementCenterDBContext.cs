using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SupportManagementCenter.Models
{
    public class SupportManagementCenterDBContext : DbContext
    {
        public SupportManagementCenterDBContext(DbContextOptions<SupportManagementCenterDBContext> options):base(options)
        {
            
        }

        public DbSet<SupportTicketModel> supportTickets { get; set; }
        public DbSet<EmployeesModel> AssignedEmployee { get; set; }
        public DbSet<ProductsModel> ProductsId { get; set; }
    }
}
