using Microsoft.AspNetCore.Mvc;
using Store.Models.Services;

namespace Store.ViewComponents;

public class SideBarMenuViewComponent : ViewComponent
{
    private readonly ILogger<SideBarMenuViewComponent> logger;
    private readonly ICategoryService categoryService;
    public SideBarMenuViewComponent(ICategoryService categoryService, ILogger<SideBarMenuViewComponent> logger)
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