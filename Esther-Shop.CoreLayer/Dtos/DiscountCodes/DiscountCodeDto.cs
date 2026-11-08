using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.DiscountCode
{
    public class DiscountCodeDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;

        public decimal Precent { get; set; }

        public bool IsActive { get; set; }

        public DateTime ExpireTime { get; set; }
    }
}
