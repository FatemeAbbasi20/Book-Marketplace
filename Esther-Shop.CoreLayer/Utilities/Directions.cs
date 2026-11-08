using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Utilities
{
    public class Directions
    {
        public const string ProductImage="wwwroot/Images/Products";
        public static string GetProductImage( string ImageName)=>$"{ProductImage.Replace("wwwroot", "")}/{ImageName}";
       
        public const string GalleryProductImage = "wwwroot/Images/GalleryProducts";
        public static string GetGalleryProductImage(string ImageName) => $"{GalleryProductImage.Replace("wwwroot", "")}/{ImageName}";

        public const string ProductContentImage = "wwwroot/Images/Products/Content";
        public static string GetProductContentImage(string ImageName) => $"{ProductContentImage.Replace("wwwroot", "")}/{ImageName}";
        
        public const string SliderImage = "wwwroot/Images/Slider";
        public static string GetSliderImage(string ImageName) => $"{SliderImage.Replace("wwwroot", "")}/{ImageName}";
       
        public const string ArticleImage = "wwwroot/Images/Articles";
        public static string GetArticleImage(string ImageName) => $"{ArticleImage.Replace("wwwroot", "")}/{ImageName}";
    }
}
