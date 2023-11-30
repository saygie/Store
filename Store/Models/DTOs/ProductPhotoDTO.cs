
namespace Store.Models.DTOs;

public class ProductPhotoDTO
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Url { get; set; } = string.Empty;
    public int Order { get; set; }
    public bool IsActive { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
    public ProductDTO? Product { get; set; }
}
