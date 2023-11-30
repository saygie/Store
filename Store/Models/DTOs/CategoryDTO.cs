using Store.Models.Entities;

namespace Store.Models.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    public int ParentCategoryId { get; set; } = 0;

    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
    public int Order { get; set; }
    public bool IsFeatured { get; set; } = false; // öne çıkan (özel) kategori

    public bool IsActive { get; set; } = false;

    public bool IsDeleted { get; set; } = false;

    public ICollection<ProductDTO>? Products { get; set; }
    public ParentCategoryDTO? ParentCategory { get; set; }
}
