
namespace Store.Models.DTOs;


public class SliderDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
    public double Price { get; set; } = 0;
    public int Order { get; set; } = 0;
    public bool IsActive { get; set; } = false;
    public bool IsDeleted { get; set; } = false;

}