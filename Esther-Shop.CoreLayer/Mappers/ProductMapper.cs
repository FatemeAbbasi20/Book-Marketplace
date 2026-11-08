using Esther_Shop.CoreLayer.Dtos.Posts;
using Esther_Shop.CoreLayer.Dtos.ProductImages;
using Esther_Shop.CoreLayer.Utilities;
using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Mappers
{
    public class ProductMapper
    {
        public static Product MapCreateDtoToProduct(CreateProductDto ProductDto)
        {
            return new Product()
            {
                Slug= ProductDto.Slug.ToSlug(),
                MetaDescription = ProductDto.MetaDescription,
                Title = ProductDto.Title,
                Price = ProductDto.Price,
               Description = ProductDto.Description,
               CategoryId= ProductDto.CategoryId,
               SubCategoryId= ProductDto.SubCategoryId,
              IsSpecial= ProductDto.IsSpecial,
              IsDelete=false,
              Visit= 0,
              DiscountPrecent=ProductDto.DiscountPrecent
              

            };
        }
        public static Product MapEditDtoToProduct(EditProductDto editDto, Product product)
        {

            product.Price = editDto.Price;
            product.Description = editDto.Description;
            product.CategoryId = editDto.CategoryId;
            product.SubCategoryId= editDto.SubCategoryId;
            product.MetaDescription= editDto.MetaDescription;
            product.Title = editDto.Title;
            product.Slug= editDto.Slug.ToSlug();
            product.IsSpecial= editDto.IsSpecial;
            product.DiscountPrecent= editDto.DiscountPrecent;
            return product;
        }

        public static ProductDto MapToProductDto(Product product)
        {
            return new ProductDto()
            {
                Price = product.Price,
                Slug = product.Slug,
                MetaDescription = product.MetaDescription,
                Visit = product.Visit,
                Title = product.Title,
                Description = product.Description,
                CategoryId = product.CategoryId,
                SubCategoryId = product.SubCategoryId,
                IsSpecial = product.IsSpecial,
                ProductId = product.Id,
                MainImageName = product.MainImageName,
                GalleryImages = product.ProductImages.Select(p => p.ImageName).ToList(),
                ProductImages = product.ProductImages.Select(images=>new ProductImagesDto() { Id=images.Id,IsMainImage=images.IsMain,Name=images.ImageName}).ToList(),
                Category = product.Category != null ? CategoryMapper.Map(product.Category) : null,
                SubCategory = product.SubCategory == null ? null : CategoryMapper.Map(product.SubCategory),
                CreationDate = product.CreationDate,
                DiscountPrecent = product.DiscountPrecent
            };
        }





    }
}
