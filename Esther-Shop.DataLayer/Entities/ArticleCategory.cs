using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.DataLayer.Entities
{
    public class ArticleCategory:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Slug { get; set; } = string.Empty;
        #region realtions
        public ICollection<Article> Article { get; set;} = new List<Article>();
        #endregion



    }
}
