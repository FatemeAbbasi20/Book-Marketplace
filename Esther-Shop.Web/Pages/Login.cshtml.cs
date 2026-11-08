using Esther_Shop.CoreLayer.Dtos.Users;
using Esther_Shop.CoreLayer.Services.User;
using Esther_Shop.CoreLayer.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Esther_Shop.Web.Pages
{
    [ValidateAntiForgeryToken]
  
    public class LoginModel : PageModel
    {
       
         private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }


        #region Properties

        [Required(ErrorMessage = "پسوورد را وارد کنید")]
            [MinLength(6, ErrorMessage = "حداقل 6 کارکتر وارد کنید")]
            [BindProperty]
            public string Password { get; set; }=string.Empty;
            [Required(ErrorMessage = "ایمیل را وارد کنید")]
            [DataType(DataType.EmailAddress)]
            [BindProperty]
        public string UserEmail { get; set; }=string.Empty;
            #endregion
            public IActionResult OnPost()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                var user = _userService.Login(new UserLoginDto()
                {
                    Password = Password,
                    UserEmail = UserEmail
                });
               
                if (user==null)
                {
                    ModelState.AddModelError("UserEmail","کاربر یافت نشد" );
                return Page();
            }

                List<Claim> Claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                     new Claim(ClaimTypes.Email,user.UserEmail),
                          new Claim(ClaimTypes.Role,user.Role.ToString())
                };

                var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrinciple = new ClaimsPrincipal(identity);
                var property = new AuthenticationProperties()
                { IsPersistent = true };
               HttpContext.SignInAsync(claimPrinciple, property);
                return RedirectToPage("/Index");

            }
        }
    }

