using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.FileManager
{
    public interface IFileManager
    {
        string SaveFileAndReturnName(IFormFile file, string SavePath);
        string SaveImageAndReturnName(IFormFile file, string SavePath);

        void DeleteFile(string fileName,string Path);
    }
}
