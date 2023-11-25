using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Models.Services;
using System.Diagnostics;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ICategoryService categoryService;
        private readonly ISliderService sliderService;

        public HomeController(ICategoryService categoryService, ISliderService sliderService, ILogger<HomeController> logger)
        {
            this.logger = logger;
            this.categoryService = categoryService;
            this.sliderService = sliderService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CategoriesWithProducts = await categoryService.ListWithProducts();
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
}
