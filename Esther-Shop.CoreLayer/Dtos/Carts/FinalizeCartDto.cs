using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Carts
{
    public class FinalizeCartDto
    {
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string PhoneNumber { get; set; } = string.Empty;
 
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Address { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
    
    }
}
