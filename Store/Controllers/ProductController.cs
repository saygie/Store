using Microsoft.AspNetCore.Mvc;
using Store.Models.Services;

namespace Store.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> logger;
    private readonly IProductService productService;

    public ProductController(IProductService productService, ILogger<ProductController> logger)
    {
        this.logger = logger;
        this.productService = productService;
    }
    public async Task<IActionResult> Index(string productSlug)
    {
        var result = await productService.GetBySlug(productSlug);
        if (result.Success)
        {
            return View(result);
        }
        return View("Error");
    }
    public async Task<IActionResult> Search(string? query, int parentCategoryId = 0)
    {
        ViewBag.MostSelledProducts = await productService.ListMostSelled();
        ViewBag.NewProducts = await productService.ListNew();
        var result = await productService.Search(query, parentCategoryId);
        if (result.Success)
        {
            return View(result);
        }
        return View("Error");
    }
}
