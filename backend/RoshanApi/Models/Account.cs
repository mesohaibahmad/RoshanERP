using System.ComponentModel.DataAnnotations;

namespace RoshanAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
        [Required] public string Type { get; set; } = string.Empty; // Asset, Liability, Income, Expense, Equity
    }
}
