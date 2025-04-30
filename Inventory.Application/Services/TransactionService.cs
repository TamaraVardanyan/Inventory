using Inventory.Application.Interfaces;
using Inventory.Infrastructure.Data;
using Inventory.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;


namespace Inventory.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> UpdateTransactionAsync(int id, Transaction transaction)
        {
            var existingTransaction = await _context.Transactions.FindAsync(transaction.ID);
            if (existingTransaction != null)
            {
                existingTransaction.ProductID = transaction.ProductID;
                existingTransaction.SupplierID = transaction.SupplierID;
                existingTransaction.Quantity = transaction.Quantity;
                existingTransaction.Status = transaction.Status;
                existingTransaction.TransactionDate = transaction.TransactionDate;
                await _context.SaveChangesAsync();
            }
            return existingTransaction;
        }

        public async Task<bool> DeleteTransactionAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
