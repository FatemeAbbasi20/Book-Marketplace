using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Categoris
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? MetaDescription { get; set; }
        public int? ParentId { get; set; }
     
    }
}
