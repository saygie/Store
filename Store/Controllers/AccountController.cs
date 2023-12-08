using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<BasketController> logger;
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<BasketController> logger)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }
}
