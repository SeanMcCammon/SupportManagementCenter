﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupportManagementCenter.Models;

namespace SupportManagementCenter.Models
{
    public class SupportManagementCenterDBContext : DbContext
    {
        public SupportManagementCenterDBContext(DbContextOptions<SupportManagementCenterDBContext> options):base(options)
        {
            
        }

        public DbSet<SupportTicketModel> supportTickets { get; set; }
        public DbSet<EmployeesModel> AssignedEmployee { get; set; }
        public DbSet<ProductsModel> Products { get; set; }
        public DbSet<TicketCorrespondenceModel> TicketCorrespondence { get; set; }
        public DbSet<TicketHistory> TicketHistories { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }
    }
}
