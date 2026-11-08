using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.DataLayer.Entities
{
    public class ProductImage : BaseEntity
    {
        [Required]
        [MaxLength(40)]
        public string ImageName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public bool IsMain { get; set; }

        #region Realations
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
        #endregion
    }
}