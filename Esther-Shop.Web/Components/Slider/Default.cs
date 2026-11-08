using Esther_Shop.CoreLayer.Services.Slider;
using Microsoft.AspNetCore.Mvc;

namespace Esther_Shop.Web.Components.Slider
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;

        public SliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IViewComponentResult Invoke()
        {
            var sliders=_sliderService.GetActiveSliders();
            return View(sliders);
        }
    }
}
