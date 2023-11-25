using Store.Models.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models.Entities;

[Table("Slider")]
public class Slider : IEntity
{
    [Key]
    public int Id { get; set; }


    [Required(AllowEmptyStrings = false)]
    [StringLength(512, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    [StringLength(int.MaxValue, MinimumLength = 3)]
    public string Description { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    [StringLength(512, MinimumLength = 3)]
    public string Link { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    [StringLength(512, MinimumLength = 3)]
    public string PhotoUrl { get; set; } = string.Empty;

    [Required]
    public double Price { get; set; } = 0;
    [Required]
    public int Order { get; set; } = 0;

    [Required]
    public bool IsActive { get; set; } = false;

    [Required]
    public bool IsDeleted { get; set; } = false;

}