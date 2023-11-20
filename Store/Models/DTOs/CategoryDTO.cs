namespace Store.Models.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    public int ParentCategoryId { get; set; } = 0;

    public string Name { get; set; } = string.Empty;

    public string SeoUrl { get; set; } = string.Empty;

    public bool IsActive { get; set; } = false;

    public bool IsDeleted { get; set; } = false;

    public ICollection<ProductDTO>? Products { get; set; }
}
