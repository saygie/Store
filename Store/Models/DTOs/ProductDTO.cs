namespace Store.Models.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SeoUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; } = 0;
    public double Price { get; set; } = 0;
    public bool IsActive { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
    public CategoryDTO? Category { get; set; }
}