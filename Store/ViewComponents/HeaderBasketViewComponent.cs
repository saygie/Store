using Microsoft.AspNetCore.Mvc;
using Store.Models.Services;

namespace Store.ViewComponents;

public class HeaderBasketViewComponent : ViewComponent
{
    private readonly ILogger<HeaderBasketViewComponent> logger;
    private readonly IBasketService basketService;
    public HeaderBasketViewComponent(IBasketService basketService, ILogger<HeaderBasketViewComponent> logger)
    {
        this.basketService = basketService;
        this.logger = logger;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var basket = await basketService.CreateOrGetSession();
        return View(basket);
    }
}