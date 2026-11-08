using Esther_Shop.CoreLayer.Dtos.Categoris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Products
{
    public class ProductSearchDataDto
    {
        public List<CategorySearchDto> Categories { get; set; } = new();
        public List<string> Author { get; set; } = new();
        public List<string> Publisher { get; set; }=new();


    }
}
