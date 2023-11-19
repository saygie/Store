using Store.Models.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.Entities;

public class Product : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(512, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    [StringLength(int.MaxValue, MinimumLength = 3)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public bool IsDeleted { get; set; } = false;
}
