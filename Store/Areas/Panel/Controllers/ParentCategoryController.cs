using Microsoft.AspNetCore.Mvc;
using Store.Models.DTOs;
using Store.Models.Services;

namespace Store.Areas.Panel.Controllers;

[Area("Panel")]
public class ParentCategoryController : Controller
{
    private readonly ILogger<ParentCategoryController> logger;
    private readonly IParentCategoryService parentCategoryService;

    public ParentCategoryController(IParentCategoryService parentCategoryService, ILogger<ParentCategoryController> logger)
    {
        this.logger = logger;
        this.parentCategoryService = parentCategoryService;
    }
    public async Task<IActionResult> List()
    {
        var result = await parentCategoryService.List();
        ViewBag.ParentCategoryCount = await parentCategoryService.Count();
        if (result.Success)
        {
            return View(result);
        }
        return View("Error");
    }
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(ParentCategoryDTO ParentCategory)
    {
        var result = await parentCategoryService.Add(ParentCategory);
        if (result.Success)
        {
            return Redirect("/Panel/ParentCategory/List");
        }
        return View("Error");
    }
    public async Task<IActionResult> Update(int id)
    {
        var result = await parentCategoryService.GetById(id);
        if (result.Success)
        {
            return View(result);
        }
        return View("Error");
    }
    [HttpPost]
    public async Task<IActionResult> Update(ParentCategoryDTO ParentCategory)
    {
        var result = await parentCategoryService.Update(ParentCategory);
        if (result.Success)
        {
            return Redirect("/Panel/ParentCategory/List");
        }
        return View("Error");
    }
    public async Task<IActionResult> Delete(int id)
    {
        var result = await parentCategoryService.Delete(new ParentCategoryDTO() { Id = id });
        if (result.Success)
        {
            return Redirect("/Panel/ParentCategory/List");
        }
        return View("Error");
    }
}
