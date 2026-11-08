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
    public class Article:BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }=string.Empty;
        [Required]
        [MaxLength(900)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(40)]
        public string ImageName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? MetaDescription { get; set; }
        [Required]
        [MaxLength(20)]
        public string Slug { get; set; } = string.Empty;
        public bool IsPublish { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        #region Realtions
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
        [ForeignKey("CategoryId")]
        public ArticleCategory ArticleCategory { get; set; } = null!;
        public ICollection<ArticleComment> ArticleComments { get; set; } = new List<ArticleComment>();

        #endregion
    }
}
