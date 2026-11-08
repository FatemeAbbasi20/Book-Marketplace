using Esther_Shop.CoreLayer.Dtos.Categoris;
using Esther_Shop.CoreLayer.Mappers;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.DataLayer.Context;
using Shop.DataLayer.Entities;


namespace Esther_Shop.CoreLayer.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
        {
            _context = context;
        }
        public OperationResult CreateCategory(CreateCategoryDto Command)
        {
            if (IsSlugExist(Command.Slug))
            {
                return OperationResult.Error("slug is existed");
            }
            var category = new Shop.DataLayer.Entities.Category()
            {
                Title= Command.Title,MetaDescription=Command.MetaDescription,
                Slug=Command.Slug.ToSlug(),ParentId=Command.ParentId,IsDelete=false
            };
            _context.Categories.Add(category);
           _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditCategory(EditCategoryDto Command)
        {      
           var category=_context.Categories.FirstOrDefault(p=>p.Id==Command.Id);
          
            if (category==null)
            {
                return OperationResult.NotFound();
            }
            if (Command.Slug.ToSlug()!= category.Slug)
                if (IsSlugExist(Command.Slug))
                {
                    return OperationResult.Error("Slug is existed ");
                }
            category.Title = Command.Title;
            category.MetaDescription = Command.MetaDescription;
            category.Slug=Command.Slug.ToSlug();
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<CategoryDto> GetAllCategory()
        {
            return _context.Categories.Select(category => CategoryMapper.Map(category)).ToList();
        }

        public CategoryDto GetCategoryById(int Id)
        {
            var category = _context.Categories.FirstOrDefault(o => o.Id == Id);
            if (category == null)
                return null;
            return CategoryMapper.Map(category);
        }

        public CategoryDto GetCategoryBySlug(string Slug)
        {
            var category = _context.Categories.FirstOrDefault(o => o.Slug == Slug);
            if (category==null) 
                return null;
            return CategoryMapper.Map(category);
        }

        public List <CategoryDto> GetChildCategories(int parentId)
        {
            return _context.Categories.Where(o => o.ParentId == parentId).Select(category => CategoryMapper.Map(category)).ToList();
           

        }

        public bool IsSlugExist(string Slug)
        {
            return _context.Categories.Any(p=>p.Slug==Slug.ToSlug());

        }
    }
}
