using Inventory.Infrastructure.Models;

namespace Inventory.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        Task<Transaction?> GetTransactionByIdAsync(int id);
        Task<Transaction> AddTransactionAsync(Transaction transaction);
        Task<Transaction> UpdateTransactionAsync(int id,Transaction transaction);
        Task<bool> DeleteTransactionAsync(int id);
    }
}
