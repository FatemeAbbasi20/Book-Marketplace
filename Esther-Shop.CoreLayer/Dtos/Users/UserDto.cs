using Esther_Shop.CoreLayer.Utilities;
using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Users
{
    public class UserDto
    {
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime RegisterDate { get; set; }
        public int UserId { get; set; }
        
    }
}
