using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(20)]
    public string? Unit { get; set; }

    public DateTime CreatedAt { get; set; }
}
