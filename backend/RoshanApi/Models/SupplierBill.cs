using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SupplierBill
{
    [Key]
    public int Id { get; set; }
    public int BillId { get; set; }

    public int SupplierId { get; set; }

    public DateTime BillDate { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal GrossAmount { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalExpense { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalCommission { get; set; }

    // Computed column (same logic as SQL persisted column)
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal NetPayable { get; private set; }

    public DateTime CreatedAt { get; set; }
}
