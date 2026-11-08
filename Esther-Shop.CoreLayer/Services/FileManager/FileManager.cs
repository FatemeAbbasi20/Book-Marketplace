using Esther_Shop.CoreLayer.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.FileManager
{
    public class FileManager : IFileManager
    {


        public string SaveFileAndReturnName(IFormFile file, string SavePath)
        {
            var fileName = $"{Guid.NewGuid()}{file.FileName}";
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), SavePath).Replace("\\", "/");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            var fullPath = Path.Combine(folderPath, fileName);
            using var stream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(stream);
            return fileName;
        }
        public void DeleteFile(string fileName, string path)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            if (File.Exists(filePath))
            { File.Delete(filePath); }
        }

        public string SaveImageAndReturnName(IFormFile file, string SavePath)
        {
            var isNotImage = !ImageValidation.Validate(file.FileName);
            if (isNotImage)
                throw new Exception();
            return SaveFileAndReturnName( file,  SavePath);
        }
    }
    }