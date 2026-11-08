using Esther_Shop.CoreLayer.Dtos.Categoris;
using Esther_Shop.CoreLayer.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos
{
    public class MainPageDto
    {
        public List<ProductDto> SpecialProducts { get; set; } = new();
        public List<ProductDto> NewestProducts { get; set; }= new();
        public List<ProductDto> DiscountedProducts { get; set; } = new();
        public List<CategorySearchDto> Categories { get; set; } = new();

    }




}
