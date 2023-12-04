namespace Store.Models.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; } = 0;
    public double PriceWithoutDiscount { get; set; } = 0;
    public double Price { get; set; } = 0;
    private int _discount = 0;
    public int Discount
    {
        get
        {
            if (PriceWithoutDiscount == 0)
            {
                return _discount;
            }
            else
            {
                return (int)(100 - (Price * 100 / PriceWithoutDiscount));
            }
        }
        set
        {
            _discount = value;
        }
    }
    public bool IsFeatured { get; set; } = false; // öne çıkan (özel) ürün
    public bool IsDiscounted { get; set; } = false; // indirimli
    public bool IsMostSelled { get; set; } = false; //çok satan
    public bool IsNew { get; set; } = false; //yeni ürün
    public bool IsSpecialOffer { get; set; } = false; // Özel Teklifli
    public DateTime? SpecialOfferEndDate { get; set; } // Özel Süresi (saat)
    public bool IsActive { get; set; } = false;
    public bool IsDeleted { get; set; } = false;

    public CategoryDTO? Category { get; set; }
    public ICollection<ProductPhotoDTO>? ProductPhotos { get; set; }
}