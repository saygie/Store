using Microsoft.AspNetCore.Mvc;
using Store.Models.Services;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this.logger = logger;
            this.productService = productService;
        }
        public async Task<IActionResult> Index(int Id)
        {
            var result = await productService.GetById(Id);
            if (result.Success)
            {
                return View(result);
            }
            return View("Error");           
        }
        public async Task<IActionResult> Show(int Id)
        {
            var result = await productService.GetById(Id);
            if (result.Success)
            {
                return View(result);
            }
            return View("Error");
        }
    }
}
