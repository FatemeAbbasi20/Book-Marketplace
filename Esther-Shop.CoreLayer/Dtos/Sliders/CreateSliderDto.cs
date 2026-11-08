using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Sliders
{
    public class CreateSliderDto
    {     [Display(Name = " عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; } = string.Empty;
        [Display(Name = "لینک ")]
        public string? Link { get; set; }
        [Display(Name = " عکس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public IFormFile ImageFile { get; set; } = null!;
      
        public int DisplayOrder { get; set; }
        [Display(Name = " اسلایدر فعال")]
        public bool IsActive { get; set; }
    }
}