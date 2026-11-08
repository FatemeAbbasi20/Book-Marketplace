using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Esther_Shop.CoreLayer.Dtos.Sliders
{
    public class EditSliderDto
    {
        public int SliderId { get; set; }
        [Display(Name = " عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; } = string.Empty;
        [Display(Name = "لینک ")]
        public string? Link { get; set; }
        [Display(Name = " عکس")]
        public IFormFile? ImageFile { get; set; } 
        public int DisplayOrder { get; set; }
        [Display(Name = " اسلایدر فعال")]
        public bool IsActive { get; set; }
    }
}