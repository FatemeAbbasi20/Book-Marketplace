using Esther_Shop.CoreLayer.Dtos.Users;
using Esther_Shop.CoreLayer.Services.User;
using Esther_Shop.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Esther_Shop.Web.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int  pageId=1)
        {
          return View (_userService.GetUserByFilter(1,pageId));
         
        }
        public IActionResult ShowEditModal(int userId )
        {
           var user= _userService.GetUserById(userId);
            var model = new EditUserDto()
            {
                FullName=user.FullName,Role=user.Role,UserId=user.UserId
            };
            return PartialView("_EditUser",model); 
        }
        [HttpPost]
        public IActionResult Edit(EditUserDto editdto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
           var result= _userService.EditUser(editdto);
            if (result.Status != OperationResultStatus.Success)
            {
                ErrorAlert(result.Message);
                return RedirectToAction("Index");
            }
            return RedirectAndShowAlert(result,RedirectToAction("Index"));
        }
    }
}
