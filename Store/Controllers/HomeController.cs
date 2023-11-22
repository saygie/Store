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

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService)
        {
            this.logger = logger;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await categoryService.ListWithProducts();
            ViewBag.CategoriesWithProducts = data;
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
