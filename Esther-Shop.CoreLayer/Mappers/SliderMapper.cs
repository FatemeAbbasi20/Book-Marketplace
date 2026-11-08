using Esther_Shop.CoreLayer.Dtos.Sliders;
using Esther_Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Mappers
{
    public class SliderMapper
    {
        public static SliderDto MapToDto(Slider slider)
        { 
            return new SliderDto()
            {
                Link = slider.Link,
                Title = slider.Title,
                DisplayOrder = slider.DisplayOrder,
                ImageName = slider.ImageName,
                IsActive = slider.IsActive,
            };

        }
    }
}
