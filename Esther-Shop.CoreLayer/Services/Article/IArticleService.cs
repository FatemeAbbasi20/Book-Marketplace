using Esther_Shop.CoreLayer.Dtos.ArticleCategories;
using Esther_Shop.CoreLayer.Dtos.Articles;
using Esther_Shop.CoreLayer.Dtos.Posts;
using Esther_Shop.CoreLayer.Dtos.Products;
using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.Article
{
    public interface IArticleService
    {
        OperationResult CreateArticle(CreateArticleDto Command);
        OperationResult EditArticle(EditArticleDto Command);
        ArticleDto GetArticleById(int ArticleId);
        ArticleDto GetArticleBySlug(string Slug);
        bool IsSlugExist(string Slug);
        ArticleFilterDto GetArticleByFilter(ArticleFilterParams filterParams);
        List<ArticleDto> GetLatestArticles();
        List<ArticleDto> GetRelatedArticles(int CategoryId);
   
    }
}
