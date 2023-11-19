using Microsoft.AspNetCore.Mvc;
using Store.Models.DTOs.Product;
using Store.Models.Services;

namespace Store.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this.logger = logger;
            this.productService = productService;
        }
        public async Task<IActionResult> List()
        {
            var result = await productService.List();
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
        public async Task<IActionResult> Add(ProductDTO product)
        {
            var result = await productService.Add(product);
            if (result.Success)
            {
                return View("List", await productService.List());
            }
            return View("Error");
        }
    }
}
