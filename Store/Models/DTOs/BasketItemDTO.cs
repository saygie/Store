using Store.Models.Entities;

namespace Store.Models.DTOs;

public class BasketItemDTO
{
    public int Id { get; set; }
    public int BasketId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public double Total { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }

    public BasketDTO? Basket { get; set; }
    public ProductDTO? Product { get; set; }
}
