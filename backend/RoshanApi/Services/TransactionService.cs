using Microsoft.EntityFrameworkCore;
using RoshanApi.DTOs;
using RoshanAPI.Data;
using RoshanAPI.Models;

namespace RoshanApi.Services
{
    public class TransactionService : ITransactionsService
    {
        private readonly AppDbContext _dbContext;

        public TransactionService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> SaveBillAsync(BillDto bill)
        {
            var now = DateTime.Now;
            foreach (var transaction in bill.Transactions)
            {
                transaction.CreatedAt = now;
                transaction.ModifiedAt = null;
            }

            await _dbContext.Transactions.AddRangeAsync(bill.Transactions);
           int result = await _dbContext.SaveChangesAsync();



            return "true"; // Includes computed Amounts after SaveChanges
        }
    }
}
