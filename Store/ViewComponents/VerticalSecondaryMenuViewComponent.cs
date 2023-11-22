using Microsoft.AspNetCore.Mvc;
using Store.Models.Services;

namespace Store.ViewComponents;

public class VerticalSecondaryMenuViewComponent : ViewComponent
{
    private readonly ILogger<VerticalSecondaryMenuViewComponent> logger;
    private readonly ICategoryService categoryService;
    public VerticalSecondaryMenuViewComponent(ICategoryService categoryService, ILogger<VerticalSecondaryMenuViewComponent> logger)
    {
        this.categoryService = categoryService;
        this.logger = logger;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await categoryService.List();
        return View(categories);
    }
    //public async Task<IViewComponentResult> InvokeAsync()
    //{
    //    return View();
    //}
}
