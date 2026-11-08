using Esther_Shop.CoreLayer.Dtos.ArticleCategories;
using Esther_Shop.CoreLayer.Dtos.Articles;
using Esther_Shop.CoreLayer.Dtos.Posts;
using Esther_Shop.CoreLayer.Dtos.Products;
using Esther_Shop.CoreLayer.Mappers;
using Esther_Shop.CoreLayer.Services.FileManager;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.DataLayer.Context;
using Esther_Shop.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.Article
{
    public class ArticleService : IArticleService
    {     private readonly BlogContext _context;
        private readonly IFileManager _fileManager;
        public ArticleService(BlogContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public OperationResult CreateArticle(CreateArticleDto Command)
        {
            if (Command.ImageFile == null)
                return OperationResult.Error();
            var article = ArticleMapper.MapCreateDtoToArticle(Command);
          article.ImageName= _fileManager.SaveFileAndReturnName(Command.ImageFile, Directions.ArticleImage);
            if (IsSlugExist(Command.Slug))
            {
                return OperationResult.Error("Slug is existed");
            }
            _context.Articles.Add(article);
            _context.SaveChanges();
           
            return OperationResult.Success();
        }

        public OperationResult EditArticle(EditArticleDto Command)
        {
            var article = _context.Articles.FirstOrDefault(p => p.Id == Command.ArticleId);
            if (article == null)
            {
                return OperationResult.NotFound();
            }
            if (article.Slug != Command.Slug.ToSlug())
                if (IsSlugExist(Command.Slug))
                {
                    return OperationResult.Error("Slug is existed");
                }
            var oldImage = article.ImageName;
            if (Command.ImageFile != null)
            {
                _fileManager.DeleteFile(oldImage, Directions.ArticleImage);
                article.ImageName = _fileManager.SaveFileAndReturnName(Command.ImageFile, Directions.ArticleImage);
            }
           
            ArticleMapper.MapEditDtoToArticle(Command, article);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public ArticleFilterDto GetArticleByFilter(ArticleFilterParams filterParams)
        {
            var result = _context.Articles.AsNoTracking().Include(c => c.ArticleCategory).OrderByDescending(p => p.CreationDate).AsQueryable();
            if (!String.IsNullOrWhiteSpace(filterParams.CategorySlug))
                result = result.Where(t => t.ArticleCategory.Slug == filterParams.CategorySlug); 
            if (!String.IsNullOrWhiteSpace(filterParams.Title))
                result = result.Where(t => t.Title.Contains( filterParams.Title));
            var skip = (filterParams.PageId - 1) * filterParams.Take;
            var model = new ArticleFilterDto()
            {
                Articles = result.Skip(skip).Take(filterParams.Take).Select(article => ArticleMapper.MapToArticleDto(article)).ToList(),
                FilterParams = filterParams
            };
            model.GeneratePaging(result, filterParams.Take, filterParams.PageId);
            return model;
        }

        public ArticleDto GetArticleById(int ArticleId)
        {
            var article = _context.Articles.Include(c => c.ArticleCategory).FirstOrDefault(y => y.Id == ArticleId);
            if (article == null)
                return null;
            return ArticleMapper.MapToArticleDto(article); 
        }

        public ArticleDto GetArticleBySlug(string Slug)
        {
            var article = _context.Articles.Include(c => c.ArticleCategory).FirstOrDefault(y => y.Slug == Slug);
            if (article == null)
                return null;
            return ArticleMapper.MapToArticleDto(article);
        }

        public List<ArticleDto> GetLatestArticles()
        {
            return _context.Articles.OrderByDescending(f=>f.Id).Take(4).Select(article => ArticleMapper.MapToArticleDto(article)).ToList();
        }

        public List<ArticleDto> GetRelatedArticles(int CategoryId)
        {
           return _context.Articles.Where(p => p.ArticleCategory.Id == CategoryId).OrderByDescending(e => e.CreationDate).Take(3).Select(article => ArticleMapper.MapToArticleDto(article)).ToList();
               
        }

        public bool IsSlugExist(string Slug)
        {

            return _context.Products.Any(f => f.Slug == Slug.ToSlug());
        }
    }
}
