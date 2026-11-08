using Esther_Shop.CoreLayer.Services.FileManager;
using Esther_Shop.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Esther_Shop.Web.Areas.Admin.Controllers
{
    [Route("/Upload/Article")]
    public class UploadArticleImageController : Controller
    { private readonly IFileManager _fileManager;

        public UploadArticleImageController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public IActionResult Index(IFormFile upload)
        {
            if (upload == null)
                return BadRequest();
            var filename = _fileManager.SaveFileAndReturnName(upload, Directions.ProductContentImage);

            return Json(new { Uploaded = true, url = Directions.GetProductContentImage(filename) });
        }
    }
}
