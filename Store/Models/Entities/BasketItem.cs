using Store.Models.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.Entities;

[Table("BasketItem")]
public class BasketItem : IEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int BasketId { get; set; }

    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }

    [Required]
    public bool IsActive { get; set; } = false;

    [Required]
    public bool IsDeleted { get; set; } = false;

    public Basket? Basket { get; set; }
    public Product? Product { get; set; }
}

