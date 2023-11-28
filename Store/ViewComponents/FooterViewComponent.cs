using Microsoft.AspNetCore.Mvc;
using Store.Models.Services;

namespace Store.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    private readonly ILogger<FooterViewComponent> logger;
    private readonly IParentCategoryService parentCategoryService;
    public FooterViewComponent(IParentCategoryService parentCategoryService, ILogger<FooterViewComponent> logger)
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