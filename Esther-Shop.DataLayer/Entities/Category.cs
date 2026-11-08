using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataLayer.Entities
{
    public class Category:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }=string.Empty;
        public string? MetaDescription { get; set; } 
        public int? ParentId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; } = string.Empty;





        #region Realations
        [InverseProperty("Category")]
        public ICollection<Product> Products {  get; set; }=new List<Product>();
        [InverseProperty("SubCategory")]
        public ICollection<Product> SubProducts { get; set; }=new List<Product>();

        #endregion
    }
}
