using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Models
{
    public class Supplier
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Suraname { get; set; } = string.Empty;
        public string PersonalData { get; set; } = string.Empty;
    }
}
