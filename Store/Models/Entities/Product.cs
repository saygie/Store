using Store.Models.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models.Entities;

[Table("Product")]
public class Product : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(32, MinimumLength = 3)]
    public string Code { get; set; } = string.Empty;

    [Required]
    public int CategoryId { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(512, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    [StringLength(512, MinimumLength = 3)]
    public string SeoUrl { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    [StringLength(int.MaxValue, MinimumLength = 3)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public int Stock { get; set; } = 0;

    [Required]
    public double Price { get; set; } = 0;

    [Required]
    public bool IsActive { get; set; } = false;

    [Required]
    public bool IsDeleted { get; set; } = false;

    public ICollection<ProductPhoto>? ProductPhotos { get; set; }
    public Category? Category { get; set; }
}
