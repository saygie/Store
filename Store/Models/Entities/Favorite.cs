using Store.Models.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models.Entities;

[Table("Favorite")]
public class Favorite : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; } = 0;

    [Required]
    public bool IsActive { get; set; } = false;

    [Required]
    public bool IsDeleted { get; set; } = false;

}
