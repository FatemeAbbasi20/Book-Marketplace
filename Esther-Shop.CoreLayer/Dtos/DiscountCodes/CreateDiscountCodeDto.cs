using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.DiscountCode
{
    public class CreateDiscountCodeDto
    {
        [Display(Name = " کد تخفیف")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Code { get; set; } = string.Empty;
        [Display(Name = " درصد تخفیف")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public decimal Precent { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = " تاریخ انقضا")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [DataType(DataType.DateTime)]
        public DateTime ExpireTime { get; set; }
    }
}
