using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Utilities
{
    public class ImageValidation
    {
        public static bool Validate(string ImageName)
        {
            var extention = Path.GetExtension(ImageName);
            if (extention == null)
                return false;
            return extention.ToLower() == "png" || extention.ToLower() == "jpg";
        }
        public static bool Validate(IFormFile file)
        {
            try
            {
                using var image = System.Drawing.Image.FromStream(file.OpenReadStream());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
