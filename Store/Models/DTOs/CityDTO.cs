
namespace Store.Models.DTOs;

public class CityDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsActive { get; set; } = false;

    public bool IsDeleted { get; set; } = false;

    public ICollection<CountyDTO>? Counties { get; set; }
}
