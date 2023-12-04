using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models.DTOs;
using Store.Models.Services;

namespace Store.Controllers;

public class BasketController : Controller
{
    private readonly ILogger<BasketController> logger;
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly IBasketService basketService;
    private readonly IBasketItemService basketItemService;
    private readonly IProductService productService;

    public BasketController(IBasketService basketService, IBasketItemService basketItemService, IProductService productService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<BasketController> logger)
    {
        this.logger = logger;
        this.userManager = userManager;
        this.basketService = basketService;
        IBasketItemService itemService = basketItemService;
        this.productService = productService;
    }
    public async Task<IActionResult> Index()
    {
        var result = await basketService.CreateOrGet();
        if (result.Success)
        {
            return View(result);
        }
        return View("Error");
    }
    [HttpPost]
    public async Task<IActionResult> Add(int productId, int quantity)
    {

        var product = await productService.GetById(productId);
        if (product == null)
            return View("Error");

        if (signInManager.IsSignedIn(User))
        {
            string? userId = userManager.GetUserId(User);
            var basket = await basketService.GetByUserId(userId);
            if (basket is null)
            {
                await basketService.Add(
                    new BasketDTO()
                    {
                        UserId = userId,
                        IsActive = true,
                        IsDeleted = false
                    });
                basket = await basketService.GetByUserId(userId);
            }

            var item = basket.Data?.BasketItems?.Where(a => a.ProductId == productId).FirstOrDefault();
            if (item is not null)
            {
                item.Quantity += quantity;
                await basketItemService.Update(item);
            }
            else
            {
                await basketItemService.Add(new BasketItemDTO()
                {
                    BasketId = basket.Data.Id,
                    IsActive = true,
                    IsDeleted = false,
                    Quantity = quantity,
                    ProductId = productId,
                });
            }

        }
        else
        {
            var basketSession = await basketService.CreateOrGet();
        }

        var result = await basketItemService.Add(new BasketItemDTO());
        if (result.Success)
        {
            return View(result);
        }
        return View("Error");
    }
}

