using Store.Models.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models.Entities;

[Table("Category")]
public class Category : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(128, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    [StringLength(128, MinimumLength = 3)]
    public string Slug { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    [StringLength(128, MinimumLength = 3)]
    public string PhotoUrl { get; set; } = string.Empty;
    [Required]
    public int Order { get; set; }
    [Required]
    public int ParentCategoryId { get; set; } = 0;
    [Required]
    public bool IsFeatured { get; set; } = false; // öne çıkan (özel) kategori

    [Required]
    public bool IsActive { get; set; } = false;

    [Required]
    public bool IsDeleted { get; set; } = false;

    public ICollection<Product>? Products { get; set; }
    public ParentCategory? ParentCategory { get; set; }
}
