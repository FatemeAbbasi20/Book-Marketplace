using Esther_Shop.CoreLayer.Dtos.Users;
using Esther_Shop.CoreLayer.Services.User;
using Esther_Shop.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace Esther_Shop.Web.Pages
{
    [ValidateAntiForgeryToken]
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }


        #region Properties

        [BindProperty]
        [Required(ErrorMessage = "پسوورد را وارد کنید")]
        [MinLength(6, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; } = string.Empty;
        [Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
        [BindProperty]
        public string FullName { get; set; } = string.Empty;
        #endregion


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result= _userService.RegisterUser(new UserRegisterDto(){
                Password=Password,UserEmail=UserEmail,FullName=FullName
            });
           
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserEmail", result.Message);
                return Page();
            }
            return RedirectToPage("/Login");

        }
    }
}
