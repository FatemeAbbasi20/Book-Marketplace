using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.ProductImages
{
    public class ProductImagesDto
    {
        public int Id { get; set; }
        public bool IsMainImage { get; set; }
        public string Name { get; set; }=string.Empty;

    }
}
