using Store.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.DTOs;

public class ProductPhotoDTO
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Url { get; set; } = string.Empty;
    public bool IsActive { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
    public ProductDTO? Product { get; set; }
}
