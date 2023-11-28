using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Store.Models.DTOs;
using Store.Models.Entities;
using Store.Models.Services;

namespace Store.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IProductPhotoService productPhotoService;

        public ProductController(IProductService productService, ILogger<ProductController> logger, ICategoryService categoryService, IProductPhotoService productPhotoService)
        {
            this.logger = logger;
            this.productService = productService;
            this.categoryService = categoryService;
            this.productPhotoService = productPhotoService;
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
        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = await categoryService.List();
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
            ViewBag.Categories = await categoryService.List();
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


        public async Task<IActionResult> PhotoUpload(int id)
        {
            var result = await productService.GetById(id);
            if (result.Success)
            {
                return View(result);
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<IActionResult> PhotoUpload(List<IFormFile> files, int productId)
        {
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await file.CopyToAsync(stream);
                            stream.Seek(0, SeekOrigin.Begin);
                            var extension = Path.GetExtension(file.FileName);
                            List<string> sizes = new List<string>()
                            {
                                "720x660","380x350","320x300","212x200","150x140","75x75"
                            };
                            var result = productPhotoService.Upload2(productId, stream, extension, "products", sizes);

                            if (result.Success)
                            {
                                return View(await productService.GetById(productId));
                            }
                        }
                    }
                }
            }
            return View("Error");
        }
        public async Task<IActionResult> PhotoDelete(int id, int productId)
        {
            var result = await productPhotoService.Delete(new ProductPhotoDTO() { Id = id });
            if (result.Success)
            {
                return View("PhotoUpload", await productService.GetById(productId));
            }
            return View("Error");
        }
    }
}
