using Esther_Shop.CoreLayer.Dtos.Posts;
using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Products
{
    public class ProductSearchDto:BasePagination
    {
        public List<ProductDto> Products { get; set; }= new List<ProductDto>();
        public ProductSearchParams SearchParams { get; set; } = null!;
    }
    public class ProductSearchParams
    {
        public string? Title { get; set; }
        public List<string>? Publisher { get; set; }
        public List<string>? Author { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinPrice { get; set; }
        public List<string>? CategorySlug { get; set; }
        private int _take { get; set; } = 12;
        public int Take
        {
            get => _take;
            set => _take = value > 0 ? value : _take = 12;
        }
        public int CurrentPage { get; set; }
        public ProductOrderBy OrderBy { get; set; }



    }
        public enum ProductOrderBy
        {
            Cheapest,
            MostExpensive,
            Popular,
            Newest,
            Title
        
    }
}
