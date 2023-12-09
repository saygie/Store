
namespace Store.Models.DTOs;


public class NeighborhoodDTO
{
    public int Id { get; set; }

    public int CountyId { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsActive { get; set; } = false;


    public bool IsDeleted { get; set; } = false;

    public CountyDTO? County { get; set; }

}