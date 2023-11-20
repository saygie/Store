using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var result = await productService.List();
            if (result.Success)
            {
                return View(result);
            }
            return View("Error");           
        }
    }
}
