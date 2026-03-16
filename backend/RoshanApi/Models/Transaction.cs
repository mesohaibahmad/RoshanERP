using System;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RoshanAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int? SupplierId { get; set; }
        public int? CustomerId { get; set; }
        public int ProductId { get; set; }

        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public int? TotalLaga { get; set; }
        public int? Discount { get; set; }

        public decimal Amount { get; set; } // Computed column

        public string? PaymentType { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }

}
