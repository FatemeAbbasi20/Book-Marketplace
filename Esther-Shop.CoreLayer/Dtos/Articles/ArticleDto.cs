using Esther_Shop.CoreLayer.Dtos.ArticleCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Articles
{
    public class ArticleDto
    {
        public int ArticleId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public string? MetaDescription { get; set; }
        public string Slug { get; set; } = string.Empty;
        public bool IsPublish { get; set; }
        public string UserFullName { get; set; }= string.Empty;
        public ArticleCategoryDto? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
