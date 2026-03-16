using System;

namespace RoshanAPI.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Side { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? Notes { get; set; }
    }
}
