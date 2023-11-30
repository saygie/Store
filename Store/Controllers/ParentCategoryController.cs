using Microsoft.AspNetCore.Mvc;
using Store.Models.Services;

namespace Store.Controllers;

public class ParentCategoryController : Controller
{
    private readonly ILogger<ParentCategoryController> logger;
    private readonly IParentCategoryService parentCategoryService;
    private readonly IProductService productService;
    public ParentCategoryController(IParentCategoryService parentCategoryService, IProductService productService, ILogger<ParentCategoryController> logger)
    {
        this.logger = logger;
        this.parentCategoryService = parentCategoryService;
        this.productService = productService;
    }

    public async Task<IActionResult> Index(string parentCategorySlug, string? categorySlug)
    {
        var result = await parentCategoryService.GetBySlugWithCategoriesAndProducts(parentCategorySlug, categorySlug);

        ViewBag.Products = await productService.Filter(parentCategorySlug, categorySlug);

        if (result.Success)
        {
            ViewData["categoryName"] = result.Data?.Categories?.Where(a=>a.Slug == categorySlug).FirstOrDefault();
            return View(result);
        }
        return View("Error");
    }
}
