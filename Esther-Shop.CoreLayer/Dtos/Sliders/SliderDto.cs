using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Sliders
{
    public class SliderDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Link { get; set; }
        public string ImageName { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
