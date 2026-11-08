using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataLayer.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
 
        public int CartId { get; set; }

        public int Count { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }


        #region Realations
        [ForeignKey("CartId")]
        public  Cart Cart { get; set; } = null!;
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
        #endregion

    }
}
