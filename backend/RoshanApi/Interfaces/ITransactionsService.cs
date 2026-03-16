using RoshanApi.DTOs;
using System.Transactions;

namespace RoshanApi.Services
{
    public interface ITransactionsService
    {
        Task<string> SaveBillAsync(BillDto bill);
    }
}