using Esther_Shop.CoreLayer.Dtos.Categoris;
using System.ComponentModel.DataAnnotations;

namespace Esther_Shop.Web.Areas.Admin.Models.Category
{
    public class CreateCategoryViewModel
    {
        [Display(Name = " عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; }=string.Empty;
        [DataType(DataType.MultilineText)]
        public string? MetaDescription { get; set; }
        public int? ParentId { get; set; }
        public string Slug { get; set; }=string.Empty ;

        public CreateCategoryDto MapToDto()
        {
            return new CreateCategoryDto()
            {
                Slug= Slug,Title= Title,MetaDescription= MetaDescription,ParentId= ParentId
            };


        }
    }

}
