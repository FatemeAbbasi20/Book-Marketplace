using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Articles
{
    public class EditArticleDto
    {
        public int ArticleId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; } = null!;
        public string? MetaDescription { get; set; }
        public string Slug { get; set; } = string.Empty;
        public bool IsPublish { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
