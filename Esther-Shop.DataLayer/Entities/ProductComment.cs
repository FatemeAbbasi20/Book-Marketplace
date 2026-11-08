using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataLayer.Entities
{
    public class ProductComment:BaseEntity
    {
     
        [MaxLength(400)]
        [Required]
        public string Text { get; set; } = string.Empty;

        public int ProductId { get; set; }
   
        public int UserId { get; set; }




        #region Realations
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
        #endregion

    }
}
