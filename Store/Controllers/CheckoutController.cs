using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models.Services;

namespace Store.Controllers;

public class CheckoutController : Controller
{
    private readonly ILogger<CheckoutController> logger;
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly IBasketService basketService;

    public CheckoutController(IBasketService basketService,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,ILogger<CheckoutController> logger)
    {
        this.logger = logger;
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.basketService = basketService;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var result = await basketService.CreateOrGetSession();
        if (result is not null)
        {
            return View(result);
        }
        return View("Error");
    }
}
