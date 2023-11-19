using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models.Services;
using Microsoft.AspNetCore.Identity;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;
        private readonly UserManager<IdentityUser> userManager;

        public ProductController(IProductService productService, ILogger<ProductController> logger, UserManager<IdentityUser> userManager)
        {
            this.logger = logger;
            this.productService = productService;
            this.userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var result = await productService.List();
            if (result.Success)
            {
                //return Ok(result);
                return View(result);
            }
            return View("Error");
            //return BadRequest(result);
            //object test = "Hello World";
            
        }
    }
}
