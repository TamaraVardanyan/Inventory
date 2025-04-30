using Inventory.Infrastructure.Models;

namespace Inventory.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(int id,Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
