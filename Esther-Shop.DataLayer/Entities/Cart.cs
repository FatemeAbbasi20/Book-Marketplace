using Esther_Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataLayer.Entities
{
    public class Cart:BaseEntity
    {
     
        public int UserId { get; set; }
        public bool IsFinal { get; set; }
        public decimal TotalPrice { get; set; }
        [Required]
        [MaxLength(20)]
        public string City { get; set; } = string.Empty;
        [Required]
        [MaxLength(40)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string Address { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Notes { get; set; }
        public int? DiscountCodeId { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public int ShippingPrice { get; set; }

        #region Realations
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
        [ForeignKey("UserId")]
        public User User { get; set; } =  null!;
        [ForeignKey("DiscountCodeId")]
        public DiscountCode? DiscountCode { get; set; } 

        #endregion

    }
    public enum ShippingMethod
    { Post,
      Tipax,
      Peyk
    }

}
