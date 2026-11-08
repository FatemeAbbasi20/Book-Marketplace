using System.ComponentModel.DataAnnotations;

namespace Esther_Shop.Web.Areas.Admin.Models.DiscountCode
{
    public class EditDiscountCodeModel
    {   public int Id { get; set; }
         [Display(Name = " کد تخفیف")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Code { get; set; } = string.Empty;
         [Display(Name = " درصد تخفیف")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Range(0,100)]
        public decimal Precent { get; set; }
        public bool IsActive { get; set; }
         [Display(Name = " تاریخ انقضا")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [DataType(DataType.DateTime)]
        public DateTime ExpireTime { get; set; }
    }
}
