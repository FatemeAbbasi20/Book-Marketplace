using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.DataLayer.Entities
{
    public class DiscountCode
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }=string.Empty;

        public decimal Precent { get; set; }

        public bool IsActive { get; set; }

        public DateTime ExpireTime { get; set; }
    }
}
