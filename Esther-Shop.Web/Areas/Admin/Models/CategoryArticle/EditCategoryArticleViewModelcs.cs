using System.ComponentModel.DataAnnotations;

namespace Esther_Shop.Web.Areas.Admin.Models.CategoryArticle
{
    public class EditCategoryArticleViewModelcs
    {
        public int Id { get; set; }
        [Display(Name = " عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; } = string.Empty;
        [Display(Name = " slug")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Slug { get; set; } = string.Empty;
    }
}
