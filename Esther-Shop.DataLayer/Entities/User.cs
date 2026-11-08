using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataLayer.Entities
{
    public class User:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public  string Password { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string UserEmail { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        
        #region Realations
        public ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();
        public ICollection<Cart> Cart { get; set; } = new List<Cart>();
        #endregion

    }
    public enum UserRole
    {
        Admin,
        User,
        Writer


    }
}
