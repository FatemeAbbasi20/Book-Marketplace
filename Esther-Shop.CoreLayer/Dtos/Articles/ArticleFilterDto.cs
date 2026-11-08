using Esther_Shop.CoreLayer.Dtos.ArticleCategories;
using Esther_Shop.CoreLayer.Dtos.Posts;
using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Articles
{
    public class ArticleFilterDto : BasePagination
    {
        public List<ArticleDto> Articles { get; set; } = new List<ArticleDto>();
        public ArticleFilterParams FilterParams { get; set; } = null!;

    }
    public class ArticleFilterParams
    {
        public int Take { get; set; }
        public int PageId { get; set; }
        public string? CategorySlug { get; set; }
        public string? Title { get; set; }
    }
}

