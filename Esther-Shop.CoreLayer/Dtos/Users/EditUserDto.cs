using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Users
{
    public class EditUserDto
    {
      
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public UserRole Role { get; set; }
        public int UserId { get; set; }
    }
}
