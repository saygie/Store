using Store.Models.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models.Entities;

[Table("Order")]
public class Order : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public bool IsActive { get; set; } = false;

    [Required]
    public bool IsDeleted { get; set; } = false;

    public ICollection<OrderDetail>? OrderDetails { get; set; }
}
