using Store.Models.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.Entities;

public class ParentCategory : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(128, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; } = false;

    [Required]
    public bool IsDeleted { get; set; } = false;

    public ICollection<Category>? Categories { get; set; }
}