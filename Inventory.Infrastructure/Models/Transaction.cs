using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Models
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        [ForeignKey(nameof(ProductID))]
        public Product? Product { get; set; }
        public int SupplierID { get; set; }
        [ForeignKey(nameof(SupplierID))]
        public Supplier? Supplier { get; set; }
        public int Quantity { get; set; }
        public string? Status { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
