using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models.DTOs;
using Store.Models.Services;
using System.Security.Claims;

namespace Store.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> logger;
    private readonly IAddressService addressService;
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    public AccountController(IAddressService addressService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.logger = logger;
        this.addressService = addressService;
    }
    public IActionResult Index()
    {
        return View();
    }
    [Authorize]
    public async Task<IActionResult> Address()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var result = await addressService.GetByUserId(userId);
        if (result is not null)
        {
            return View(result);
        }
        return View("Error");
    }



    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddressAdd(int addressId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var result = await addressService.Delete(new AddressDTO() { Id = addressId, UserId = userId });
        if (result.Success)
        {
            return RedirectToAction("Address");
        }
        return View("Error");
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddressEdit(int addressId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var result = await addressService.Delete(new AddressDTO() { Id = addressId, UserId = userId });
        if (result.Success)
        {
            return RedirectToAction("Address");
        }
        return View("Error");
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddressDelete(int addressId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var result = await addressService.Delete(new AddressDTO() { Id = addressId, UserId = userId });
        if (result.Success)
        {
            return RedirectToAction("Address");
        }
        return View("Error");
    }
}
