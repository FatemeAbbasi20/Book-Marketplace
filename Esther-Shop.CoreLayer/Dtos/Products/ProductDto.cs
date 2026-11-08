using Esther_Shop.CoreLayer.Dtos.Categoris;
using Esther_Shop.CoreLayer.Dtos.ProductImages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Posts
{
    public class ProductDto
    {
        public  int Id { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? MetaDescription { get; set; }
        public int Visit { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? DiscountPrecent { get; set; }
        public bool IsSpecial { get; set; }
        public string MainImageName { get; set; } = string.Empty;
        public int Stock { get; set; }
        public bool IsInSlider { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public string? Trenslator { get; set; }
        public string Author { get; set; } = string.Empty;
        public List<string> GalleryImages { get; set; } = new();
        public List<ProductImagesDto> ProductImages { get; set; } = new List<ProductImagesDto>();
        public CategoryDto? Category { get; set; } 
        public CategoryDto? SubCategory { get; set; }
        public DateTime CreationDate { get; set; }



        public Decimal GetFinalPrice()
        {
            if (DiscountPrecent == null || DiscountPrecent == 0)
                return (Decimal)Price;
            return (Decimal)(Price - (Price * DiscountPrecent.Value / 100));

        }
    }
}
