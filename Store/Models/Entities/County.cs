using Store.Models.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models.Entities;

[Table("County")]
public class County : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CityId { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(128, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public bool IsActive { get; set; } = false;

    [Required]
    public bool IsDeleted { get; set; } = false;

    public City? City { get; set; }
    public ICollection<Neighborhood>? Neighborhoods { get; set; }
}
