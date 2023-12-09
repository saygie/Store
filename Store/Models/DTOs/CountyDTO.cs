
namespace Store.Models.DTOs;

public class CountyDTO
{
    public int Id { get; set; }

    public int CityId { get; set; }


    public string Name { get; set; } = string.Empty;

    public bool IsActive { get; set; } = false;


    public bool IsDeleted { get; set; } = false;

    public CityDTO? City { get; set; }
    public ICollection<NeighborhoodDTO>? Neighborhoods { get; set; }
}
