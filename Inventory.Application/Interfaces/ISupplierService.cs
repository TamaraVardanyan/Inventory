using Inventory.Infrastructure.Models;

namespace Inventory.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier> GetSupplierByIdAsync(int id);
        Task<Supplier> AddSupplierAsync(Supplier supplier);
        Task<Supplier> UpdateSupplierAsync(int id,Supplier supplier);
        Task<bool> DeleteSupplierAsync(int id);
    }
}
