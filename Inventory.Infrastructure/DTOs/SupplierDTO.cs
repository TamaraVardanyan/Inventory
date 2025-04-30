using System.ComponentModel.DataAnnotations;

namespace Inventory.Infrastructure.DTOs
{
    public class SupplierDTO
    {
        [Required(ErrorMessage = "Supplier name is required.")]
        [StringLength(100, ErrorMessage = "Supplier name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Supplier Suraname is required.")]
        [StringLength(100, ErrorMessage = "Supplier Suraname cannot be longer than 100 characters.")]
        public string Suraname { get; set; } = string.Empty;
        public string PersonalData { get; set; } = string.Empty;
    }
}
