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
        var result = await basketService.CreateOrGetSession();
        if (result is not null)
        {
            return View(result);
        }
        return View("Error");
    }
    [HttpGet]
    public async Task<IActionResult> Add(int productId, int quantity = 1)
    {

        await basketService.AddToSession(productId, quantity);
        var result = await basketService.CreateOrGetSession();
        if (result is not null)
        {
            return ViewComponent("HeaderBasket", result);
        }
        return View("Error");
    }
    [HttpGet]
    public async Task<IActionResult> RemoveItem(int productId)
    {
        var result = await basketService.RemoveItemInSession(productId);
        if (result is not null)
        {
            return RedirectToAction("Index");
        }
        return View("Error");
    }
    [HttpGet]
    public async Task<IActionResult> IncreaseItemQuantity(int productId, int quantity = 1)
    {

        await basketService.AddToSession(productId, quantity);
        var result = await basketService.CreateOrGetSession();
        if (result is not null)
        {
            return RedirectToAction("Index");
        }
        return View("Error");
    }
    [HttpGet]
    public async Task<IActionResult> DecreaseItemQuantity(int productId, int quantity = -1)
    {

        await basketService.AddToSession(productId, quantity);
        var result = await basketService.CreateOrGetSession();
        if (result is not null)
        {
            return RedirectToAction("Index");
        }
        return View("Error");
    }
}


