using Store.Models.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.Entities;


[Table("Address")]
public class Address : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(64)]
    public string UserId { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    [StringLength(128, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    [StringLength(128, MinimumLength = 3)]
    public string FirstName { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    [StringLength(128, MinimumLength = 3)]
    public string LastName { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false)]
    [StringLength(16, MinimumLength = 3)]
    public string Phone { get; set; } = string.Empty;

    [Required]
    public int NeighborhoodId { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(256, MinimumLength = 3)]
    public string AddressDetail { get; set; } = string.Empty;

    [Required]
    public bool IsCorporate { get; set; } = false;

    [StringLength(256)]
    public string? TaxIdentificationNumber { get; set; }

    [StringLength(256)]
    public string? TaxAdministration { get; set; }
    [StringLength(256)]
    public string? CorporateName { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    public bool IsDeleted { get; set; } = false;
    public Neighborhood? Neighborhood { get; set; }

}
