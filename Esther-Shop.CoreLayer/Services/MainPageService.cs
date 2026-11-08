using Esther_Shop.CoreLayer.Dtos;
using Esther_Shop.CoreLayer.Dtos.Categoris;
using Esther_Shop.CoreLayer.Mappers;
using Esther_Shop.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services
{
    public class MainPageService : IMainPageService
    {
        private readonly BlogContext _context;

        public MainPageService(BlogContext context)
        {
            _context = context;
        }

        public MainPageDto GetData()
        {  
            var specialProducts=_context.Products.Where(c=>c.IsSpecial).Take(8).Select(Product=>ProductMapper.MapToProductDto(Product)).ToList();
            var newestProducts=_context.Products.OrderByDescending(d=>d.Id).Take(10).Select(Product => ProductMapper.MapToProductDto(Product)).ToList();
            var categories = _context.Categories.Take(8).OrderByDescending(d => d.Id).Select(categories => new CategorySearchDto()
            {
                Id = categories.Id,
                Title = categories.Title,
                Slug = categories.Slug,
                ParentId = categories.ParentId
            }).ToList();
            var discountedProducts=_context.Products.Where(p=>p.DiscountPrecent!=null).OrderByDescending(d=>d.DiscountPrecent).Take(6).Select(Product => ProductMapper.MapToProductDto(Product)).ToList();
            return new MainPageDto()
            {
                Categories = categories,
                NewestProducts = newestProducts,
                SpecialProducts= specialProducts,
                DiscountedProducts= discountedProducts
            };
        }
    }
}
