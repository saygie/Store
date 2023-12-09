using Store.Models.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.Entities;


[Table("Basket")]
public class Basket:IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(64)]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    public bool IsDeleted { get; set; } = false;
    public ICollection<BasketItem>? BasketItems { get; set; }
}
