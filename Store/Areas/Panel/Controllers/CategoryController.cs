using Microsoft.AspNetCore.Mvc;
using Store.Models.DTOs;
using Store.Models.Services;

namespace Store.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> logger;
        private readonly ICategoryService categoryService;
        private readonly IParentCategoryService parentCategoryService;

        public CategoryController(ICategoryService categoryService, IParentCategoryService parentCategoryService, ILogger<CategoryController> logger)
        {
            this.logger = logger;
            this.categoryService = categoryService;
            this.parentCategoryService = parentCategoryService;
        }
        public async Task<IActionResult> List()
        {
            var result = await categoryService.List();
            ViewBag.CategoryCount = await categoryService.Count();
            if (result.Success)
            {
                return View(result);
            }
            return View("Error");
        }
        public async Task<IActionResult> Add()
        {
            ViewBag.ParentCategories = await parentCategoryService.List();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryDTO Category)
        {
            var result = await categoryService.Add(Category);
            if (result.Success)
            {
                return Redirect("/Panel/Category/List");
            }
            return View("Error");
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.ParentCategories = await parentCategoryService.List();
            var result = await categoryService.GetById(id);
            if (result.Success)
            {
                return View(result);
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryDTO Category)
        {
            var result = await categoryService.Update(Category);
            if (result.Success)
            {
                return Redirect("/Panel/Category/List");
            }
            return View("Error");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await categoryService.Delete(new CategoryDTO() { Id = id });
            if (result.Success)
            {
                return Redirect("/Panel/Category/List");
            }
            return View("Error");
        }
    }
}
