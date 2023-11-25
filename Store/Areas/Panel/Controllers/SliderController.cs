using Microsoft.AspNetCore.Mvc;
using Store.Models.DTOs;
using Store.Models.Services;

namespace Store.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class SliderController : Controller
    {
        private readonly ILogger<SliderController> logger;
        private readonly ISliderService sliderService;
        private readonly IHelperService helperService;

        public SliderController(ISliderService sliderService, ILogger<SliderController> logger, IHelperService helperService)
        {
            this.logger = logger;
            this.sliderService = sliderService;
            this.helperService = helperService;
        }
        public async Task<IActionResult> List()
        {
            var result = await sliderService.List();
            ViewBag.SliderCount = await sliderService.Count();
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
        public async Task<IActionResult> Add(SliderDTO slider, IFormFile file)
        {
            if (file != null)
            {
                if (file.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        stream.Seek(0, SeekOrigin.Begin);
                        var name = Guid.NewGuid().ToString();
                        var extension = Path.GetExtension(file.FileName);

                        helperService.PhotoUpload(stream, name, extension, "slider", "416x420");

                        slider.PhotoUrl = name + extension;
                        var result = await sliderService.Add(slider);
                        if (result.Success)
                        {
                            return Redirect("/Panel/Slider/List");
                        }
                    }
                }
            }
            return View("Error");

        }
        public async Task<IActionResult> Update(int id)
        {
            var result = await sliderService.GetById(id);
            if (result.Success)
            {
                return View(result);
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Update(SliderDTO Slider)
        {
            var result = await sliderService.Update(Slider);
            if (result.Success)
            {
                return Redirect("/Panel/Slider/List");
            }
            return View("Error");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await sliderService.Delete(new SliderDTO() { Id = id });
            if (result.Success)
            {
                return Redirect("/Panel/Slider/List");
            }
            return View("Error");
        }
    }
}
