using Esther_Shop.Web.Areas.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Esther_Shop.Web.Area.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
