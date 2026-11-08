using Esther_Shop.CoreLayer.Dtos.Sliders;
using Esther_Shop.CoreLayer.Services.Slider;
using Esther_Shop.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Esther_Shop.Web.Areas.Admin.Controllers
{
    public class SliderController : AdminBaseController
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult Index( )
        {
           var Slider= _sliderService.GetAllSliders();
            return View (Slider);

            
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateSliderDto createdto)
        {
            if (!ModelState.IsValid)
            {
                return View(createdto);
            }
           var result=_sliderService.CreateSlider(createdto);
            return RedirectAndShowAlert(result, RedirectToAction("Index"));

        }
        public IActionResult Edit(int id )
        {
            var slider = _sliderService.GetSliderById(id);
            if (slider == null) { return NotFound(); }
            var model = new EditSliderDto()
            {
                Link= slider.Link,IsActive=slider.IsActive,DisplayOrder=slider.DisplayOrder,Title=slider.Title
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id,EditSliderDto EditDto)
        {
            if (!ModelState.IsValid)
            {
                return View(EditDto);
            }
            var result= _sliderService.EditSlider(EditDto);
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError("",result.Message);
                return View(EditDto);
            }
            return RedirectAndShowAlert(result, RedirectToAction("Index"));
        }
    }
}
