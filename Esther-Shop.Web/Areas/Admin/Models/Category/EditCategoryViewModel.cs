using System.ComponentModel.DataAnnotations;

namespace Esther_Shop.Web.Areas.Admin.Models.Category
{
    public class EditCategoryArticleViewModel
    {
        public int Id { get; set; }
        [Display(Name = " عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; } = string.Empty;
        [DataType(DataType.MultilineText)]
        public string? MetaDescription { get; set; }
        [Display(Name = " Slug")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Slug { get; set; }=string.Empty;
    }
}
