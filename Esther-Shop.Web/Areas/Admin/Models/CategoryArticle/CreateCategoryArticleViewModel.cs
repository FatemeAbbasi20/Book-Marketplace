using Esther_Shop.CoreLayer.Dtos.ArticleCategories;
using System.ComponentModel.DataAnnotations;

namespace Esther_Shop.Web.Areas.Admin.Models.CategoryArticle
{
    public class CreateCategoryArticleViewModel
    {
        [Display(Name = " عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; } = string.Empty;
        [Display(Name = " slug")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Slug { get; set; } = string.Empty;


        public CreateArticleCategoryDto MapToDto()
        {
            return new CreateArticleCategoryDto()
            {
                Title= Title,
                Slug= Slug,
            };
        }
    }
}
