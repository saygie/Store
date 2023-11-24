using Microsoft.AspNetCore.Mvc;
using Store.Models.Services;

namespace Store.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    private readonly ILogger<HeaderViewComponent> logger;
    private readonly ICategoryService categoryService;
    public HeaderViewComponent(ICategoryService categoryService, ILogger<HeaderViewComponent> logger)
    {
        this.categoryService = categoryService;
        this.logger = logger;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await categoryService.List();
        return View(categories);
    }
}
