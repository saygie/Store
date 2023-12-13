using Store.Models.Entities;

namespace Store.Models.DTOs;

public class AddressDTO
{
    public int Id { get; set; }
    public string GId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public int NeighborhoodId { get; set; }

    public string AddressDetail { get; set; } = string.Empty;

    public bool IsCorporate { get; set; } = false;

    public string? TaxIdentificationNumber { get; set; }

    public string? TaxAdministration { get; set; }

    public string? CorporateName { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

    public NeighborhoodDTO? Neighborhood { get; set; }
}
