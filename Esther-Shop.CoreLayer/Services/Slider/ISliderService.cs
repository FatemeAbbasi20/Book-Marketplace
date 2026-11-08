using Esther_Shop.CoreLayer.Dtos.Categoris;
using Esther_Shop.CoreLayer.Dtos.Sliders;
using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.Slider
{
    public interface ISliderService
    {
        OperationResult CreateSlider(CreateSliderDto Command);
        List<SliderDto> GetAllSliders();
        List<SliderDto> GetActiveSliders();
        OperationResult EditSlider(EditSliderDto Command);
        SliderDto GetSliderById(int sliderId);
    }
}
