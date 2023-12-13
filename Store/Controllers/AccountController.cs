using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Services;
using System.Diagnostics.Metrics;
using System.Security.Claims;

namespace Store.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> logger;
    private readonly IAddressService addressService;
    private readonly ICityService cityService;
    private readonly ICountyService countyService;
    private readonly INeighborhoodService neighborhoodService;

    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    public AccountController(IAddressService addressService, ICityService cityService, ICountyService countyService, INeighborhoodService neighborhoodService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.logger = logger;
        this.addressService = addressService;
        this.cityService = cityService;
        this.countyService = countyService;
        this.neighborhoodService = neighborhoodService;
    }
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
    [Authorize]
    public IActionResult Info()
    {
        return View();
    }
    [Authorize]
    public async Task<IActionResult> Address()
    {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await addressService.GetByUserId(userId);
        ViewBag.Cities = await cityService.List();
        if (result is not null)
        {
            return View(result);
        }
        return View("Error");
    }



    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddressAdd(AddressDTO dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        dto.UserId = userId;
        var result = await addressService.Add(dto);
        if (result.Success)
        {
            return RedirectToAction("Address");
        }
        return View("Error");
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> AddressEdit(string gId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        ViewBag.Cities = await cityService.List();
        ViewBag.Counties = await countyService.List();
        ViewBag.Neighborhoods = await neighborhoodService.List();

        var result = await addressService.GetByGId(gId, userId);
        if (result.Success)
        {
            return View(result);
        }
        return View("Error");
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddressEdit(AddressDTO dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        dto.UserId = userId;
        var address = await addressService.GetByGId(dto.GId);
        dto.Id = address.Data.Id;
        var result = await addressService.Update(dto);
        if (result.Success)
        {
            return RedirectToAction("Address");
        }
        return View("Error");
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddressDelete(string addressGId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var result = await addressService.Delete(new AddressDTO() { GId = addressGId, UserId = userId });
        if (result.Success)
        {
            return RedirectToAction("Address");
        }
        return View("Error");
    }

    public async Task<IActionResult> GetCounties(int cityId)
    {

        var result = await countyService.ListByCityId(cityId);
        if (result.Success)
        {
            return Json(result.Data);
        }
        return View("Error");
    }
    public async Task<IActionResult> GetNeighborhoods(int countyId)
    {

        var result = await neighborhoodService.ListByCountyId(countyId);
        if (result.Success)
        {
            return Json(result.Data);
        }
        return View("Error");
    }
}
