using Microsoft.AspNetCore.Mvc;
using Store.Models.DTOs.Product;
using Store.Models.Entities;
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
            ViewBag.ProductCount = await productService.Count();
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
                return Redirect("/Panel/Product/List");
            }
            return View("Error");
        }
        public async Task<IActionResult> Update(int id)
        {
            var result = await productService.GetById(id);
            if (result.Success)
            {
                return View(result);
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDTO product)
        {
            var result = await productService.Update(product);
            if (result.Success)
            {
                return Redirect("/Panel/Product/List");
            }
            return View("Error");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await productService.Delete(new ProductDTO() { Id = id });
            if (result.Success)
            {
                return Redirect("/Panel/Product/List");
            }
            return View("Error");
        }
    }
}
