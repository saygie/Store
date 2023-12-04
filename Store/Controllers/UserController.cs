using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models.Services;

namespace Store.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> logger;
        private readonly IProductService productService;
        private readonly UserManager<IdentityUser> userManager;

        public UserController(UserManager<IdentityUser> userManager, ILogger<UserController> logger)
        {
            this.logger = logger;
            this.userManager = userManager;
        }
    }
}
