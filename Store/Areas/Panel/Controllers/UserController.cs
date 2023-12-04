using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Store.Areas.Panel.Controllers;

[Area("Panel")]
public class UserController : Controller
{
    private readonly ILogger<UserController> logger;
    private readonly UserManager<IdentityUser> userManager;

    public UserController(UserManager<IdentityUser> userManager, ILogger<UserController> logger)
    {
        this.logger = logger;
        this.userManager = userManager;
    }
    public async Task<IActionResult> List()
    {
        var users = await userManager.Users.ToListAsync();
        return View(users);
    }
}
