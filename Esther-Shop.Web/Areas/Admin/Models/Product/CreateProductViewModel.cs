using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Esther_Shop.Web.Areas.Admin.Models.Product
{
    public class CreateProductViewModel
    {
        [Display(Name = " عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; } = string.Empty;
        [Display(Name = " توضیحات")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [UIHint("CkEditor4")]
        public string Description { get; set; } = string.Empty;
        [Display(Name = " slug")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Slug { get; set; } = string.Empty;
        [Display(Name = " قیمت")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public decimal Price { get; set; }
        [DataType(DataType.MultilineText)]
        public string? MetaDescription { get; set; } 
        [Display(Name = " عکس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public IFormFile MainImageFile { get; set; } = null!;
        [Display(Name="انتخاب دسته بندی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int CategoryId { get; set; }
        [Display(Name = "انتخاب زیر دسته بندی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int? SubCategoryId { get; set; }
        [Display(Name = "پست ویژه ؟")]
        public bool IsSpecial { get; set; }
        [Display(Name = " موجودی محصول")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int Stock { get; set; }
        public bool IsInSlider { get; set; }
        [Display(Name = " ناشر")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Publisher { get; set; } = string.Empty;
        [Display(Name = " مترجم")]
        public string? Trenslator { get; set; }
        [Display(Name = " نویسنده")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Author { get; set; } = string.Empty;
        [Display(Name = " گالری تصاویر  ")]
        public List<IFormFile>? GalleryImages { get; set; }
        [Display(Name = "درصد تخفیف")]
        public int? DiscountPrecent { get; set; }
    }
}
