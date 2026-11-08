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
    public class ArticleComment : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Text { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int ArticleId { get; set; }
     
        #region Realtions
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
        [ForeignKey("ArticleId")]
        public Article Article { get; set; } = null!;
        #endregion
    }
}
