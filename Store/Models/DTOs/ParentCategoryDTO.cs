namespace Store.Models.DTOs;

public class ParentCategoryDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
    public int Order { get; set; }
    public bool IsActive { get; set; } = false;

    public bool IsDeleted { get; set; } = false;

    public ICollection<CategoryDTO>? Categories { get; set; }
}
