using Esther_Shop.CoreLayer.Dtos.ArticleCategories;
using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.ArticleCategory
{
    public interface IArticleCategoryService
    {
        OperationResult CreateArticleCategory(CreateArticleCategoryDto Command);
        OperationResult EditArticleCategory(EditArticleCategoryDto Command);
        List<ArticleCategoryDto> GetAllArticleCategory();
        ArticleCategoryDto GetArticleCategoryById(int id);
        bool IsSlugExist(string Slug);
    }
}
