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
    public class Product:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(400)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(40)]
        public string Author { get; set; } = string.Empty;
        public string? Translator { get; set; }
        [Required]
        [MaxLength(40)]
        public string Publisher { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required]
        public string Slug { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        public int Visit { get; set; }
        [MaxLength(100)]
        public string? MetaDescription { get; set; }
        [Required]
        [MaxLength(40)]
        public string MainImageName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public bool IsInSlider { get; set; }
        public bool IsSpecial { get; set; }
        public int Stock { get; set; }
        public int? DiscountPrecent { get; set; }

        #region Realations
        [ForeignKey("CategoryId")]
        public Category Category{ get; set; }=null!;

        [ForeignKey("SubCategoryId")]
        public Category SubCategory { get; set; } = null!;
        public ICollection<ProductComment> ProductComments { get; set; }=new List<ProductComment>();
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        #endregion
     

    }
}
