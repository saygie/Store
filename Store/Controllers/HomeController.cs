using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Models.Services;
using System.Diagnostics;

namespace Store.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;
    private readonly IProductService productService;
    private readonly ICategoryService categoryService;
    private readonly IParentCategoryService parentCategoryService;
    private readonly ISliderService sliderService;

    public HomeController(IProductService productService,IParentCategoryService parentCategoryService,ICategoryService categoryService, ISliderService sliderService, ILogger<HomeController> logger)
    {
        this.logger = logger;
        this.productService = productService;
        this.parentCategoryService = parentCategoryService;
        this.categoryService = categoryService;
        this.sliderService = sliderService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.HomePageProducts = await productService.ListForHomePage();
        ViewBag.CategoriesWithProducts = await categoryService.ListWithParentCategoryAndProducts();
        ViewBag.parentCategoriesWithProducts = await parentCategoryService.List();
        ViewBag.Slider = await sliderService.List();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
