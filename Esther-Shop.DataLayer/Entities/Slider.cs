using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.DataLayer.Entities
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Title { get; set; } = string.Empty;
        public string? Link { get; set; }
        [Required]
        [MaxLength(40)]
        public string ImageName { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }

    }
}
