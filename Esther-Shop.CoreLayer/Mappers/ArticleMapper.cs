using Esther_Shop.CoreLayer.Dtos.ArticleCategories;
using Esther_Shop.CoreLayer.Dtos.Articles;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Mappers
{
    public class ArticleMapper
    {
       public static Article MapCreateDtoToArticle(CreateArticleDto createArticleDto)
        {
            return new Article
            {
                Title = createArticleDto.Title,
                Description = createArticleDto.Description,
                MetaDescription = createArticleDto.MetaDescription,
                Slug = createArticleDto.Slug.ToSlug(),
                IsPublish = createArticleDto.IsPublish,
                UserId = createArticleDto.UserId
            };
        }
        public static Article MapEditDtoToArticle(EditArticleDto editArticle,Article article)
        { 
          article.Description=editArticle.Description;
          article.MetaDescription=editArticle.MetaDescription;
          article.Title=editArticle.Title;
          article.Slug=editArticle.Slug.ToSlug();
          article.IsPublish=editArticle.IsPublish;
          article.UserId=editArticle.UserId;
            return article;
        }
        public static ArticleDto MapToArticleDto(Article article)
        {
            return new ArticleDto
            { CategoryId = article.CategoryId,
              IsPublish=article.IsPublish,
                UserFullName = article.User.FullName,
              Description=article.Description,
              Title=article.Title,
              MetaDescription=article.MetaDescription,
              Slug=article.Slug.ToSlug(),
              ImageName=article.ImageName,
              CreationDate=article.CreationDate,
              Category=article.ArticleCategory!=null?new ArticleCategoryDto() { Id=article.ArticleCategory.Id,Title= article.ArticleCategory.Title,Slug=article.ArticleCategory.Slug}:null
            };
         } 

        
    }
}
