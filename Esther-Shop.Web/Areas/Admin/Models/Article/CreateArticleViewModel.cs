using System.ComponentModel.DataAnnotations;

namespace Esther_Shop.Web.Areas.Admin.Models.Article
{
    public class CreateArticleViewModel
    {   [Display(Name = " عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; } = string.Empty;
        [Display(Name = " توضیحات")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [UIHint("CkEditor4")]
        public string Description { get; set; } = string.Empty;
        [Display(Name = " عکس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public IFormFile ImageFile { get; set; } = null!;
        [DataType(DataType.MultilineText)]
        public string? MetaDescription { get; set; }
         [Display(Name = "slug")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Slug { get; set; } = string.Empty;
        [Display(Name = "منتشر شده")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public bool IsPublish { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
