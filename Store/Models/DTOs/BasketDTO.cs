using Store.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.DTOs;

public class BasketDTO
{

    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public double SubTotal { get; set; }
    public double Total { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<BasketItemDTO>? BasketItems { get; set; }
}
