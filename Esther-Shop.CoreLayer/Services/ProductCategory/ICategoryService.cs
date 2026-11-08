using Esther_Shop.CoreLayer.Dtos.Categoris;
using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.Category
{
    public interface ICategoryService
    {
        OperationResult CreateCategory(CreateCategoryDto Command);
        OperationResult EditCategory(EditCategoryDto Command);
        List<CategoryDto>GetAllCategory();
        CategoryDto GetCategoryById(int Id);    
        CategoryDto GetCategoryBySlug(string Slug);
        bool IsSlugExist(string Slug);
       List<CategoryDto> GetChildCategories(int parentId);
   

    }
}
