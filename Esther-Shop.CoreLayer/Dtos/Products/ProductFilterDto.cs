using Esther_Shop.CoreLayer.Dtos.Posts;
using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Products
{
    public class ProductFilterDto: BasePagination
    {
        public List<ProductDto> Products { get; set; }=new List<ProductDto>();
        public ProductFilterParams FilterParams { get; set; } = null!;

    }
        public class ProductFilterParams
        {
            public int Take { get; set; }
            public int PageId { get; set; }
            public string? CategorySlug { get; set; }
            public string? Title { get; set; }
        }


    
}
