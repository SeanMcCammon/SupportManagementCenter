using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportManagementCenter.Models
{
    public class ProductsModel
    {
        [Key]
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProduceDescription { get; set; }

        public string Notes { get; set; }
    }
}
