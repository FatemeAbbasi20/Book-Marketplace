using Esther_Shop.CoreLayer.Dtos.ProductImages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Posts
{
    public class EditProductDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? MetaDescription { get; set; }
        public IFormFile? MainImageFile { get; set; }
        public int Stock { get; set; }
        public bool? IsInSlider { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public string? Trenslator { get; set; }
        public string Author { get; set; } = string.Empty;
        public List<IFormFile>? GalleryImages { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public bool IsSpecial { get; set; }
        public int? DiscountPrecent { get; set; }
    }
}
