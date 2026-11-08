using Esther_Shop.CoreLayer.Dtos.Categoris;
using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDto Map(Category category) 
        {
            return new CategoryDto()
            {
                MetaDescription = category.MetaDescription,
                Slug = category.Slug,
                Title = category.Title,
                ParentId = category.ParentId,
                Id  = category.Id
            };
        }

    }
}
