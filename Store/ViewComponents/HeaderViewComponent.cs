using Microsoft.AspNetCore.Mvc;
using Store.Models.Services;

namespace Store.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    private readonly ILogger<HeaderViewComponent> logger;
    private readonly IParentCategoryService parentCategoryService;
    public HeaderViewComponent(IParentCategoryService parentCategoryService, ILogger<HeaderViewComponent> logger)
    {
        this.parentCategoryService = parentCategoryService;
        this.logger = logger;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await parentCategoryService.List();
        return View(categories);
    }
}
