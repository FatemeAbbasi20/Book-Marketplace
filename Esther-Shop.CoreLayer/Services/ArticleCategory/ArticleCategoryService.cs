using Esther_Shop.CoreLayer.Dtos.ArticleCategories;
using Esther_Shop.CoreLayer.Mappers;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.DataLayer.Context;

namespace Esther_Shop.CoreLayer.Services.ArticleCategory
{
    public class ArticleCategoryService : IArticleCategoryService
    {
        private readonly BlogContext _context;

        public ArticleCategoryService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreateArticleCategory(CreateArticleCategoryDto Command)
        {
            if (IsSlugExist(Command.Slug))
            {
                return OperationResult.Error("Slug is existed ");
            }
            var Category=new DataLayer.Entities.ArticleCategory()
            {
                Title = Command.Title, 
                Slug = Command.Slug.ToSlug(),
                IsDelete = false
            };
            _context.ArticleCategories.Add(Category);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditArticleCategory(EditArticleCategoryDto Command)
        {
            var category = _context.Categories.FirstOrDefault(p => p.Id == Command.Id);

            if (category == null)
            {
                return OperationResult.NotFound();
            }
            if (Command.Slug.ToSlug() != category.Slug)
                if (IsSlugExist(Command.Slug))
                {
                    return OperationResult.Error("Slug is existed ");
                }
            category.Title = Command.Title;
            category.Slug = Command.Slug.ToSlug();
            _context.SaveChanges();
            return OperationResult.Success();

        }

        public List<ArticleCategoryDto> GetAllArticleCategory()
        {
            return _context.Categories.Select(category =>new ArticleCategoryDto() { Id=category.Id,Slug=category.Slug,Title=category.Title}).ToList();
        }

        public ArticleCategoryDto GetArticleCategoryById(int id)
        {
            var category = _context.Categories.FirstOrDefault(o => o.Id == id);
            if (category == null)
                return null;
            return new ArticleCategoryDto() { Id = category.Id, Slug = category.Slug, Title = category.Title };
        }
        public bool IsSlugExist(string Slug)
        {
            return _context.ArticleCategories.Any(p => p.Slug == Slug.ToSlug());

        }
    }
}
