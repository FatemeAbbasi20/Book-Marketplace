using Esther_Shop.CoreLayer.Dtos.Carts;
using Esther_Shop.CoreLayer.Services.Card;
using Esther_Shop.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Esther_Shop.Web.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly ICartService _cartService;

        public CheckoutModel(ICartService cartService)
        {
            _cartService = cartService;
        }
        [BindProperty]
        public  FinalizeCartDto FinalCart { get; set; }
        public CartDto Cart { get; set; }

        [Required(ErrorMessage = "کد تخفیف را وارد کنید")]
        [BindProperty(SupportsGet = true)]
        public string DiscountTitle { get; set; }
        public IActionResult OnGet()
        {
            var userId = User.GetUserId();
           Cart= _cartService.GetCart(userId);
            if (Cart == null)
            {
                return RedirectToPage("Cart");
            }
            return Page();
        }
        public IActionResult OnPostCheckout()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            var userId = User.GetUserId();
            var DiscounResult = _cartService.ApplyDiscount(userId, DiscountTitle);
            if (DiscounResult.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(DiscountTitle), DiscounResult.Message);
                return RedirectToPage();
            }
            var FinalResult = _cartService.Finalize(userId, FinalCart);
            if (FinalResult.Status != OperationResultStatus.Success)
            {
                TempData["ErrorMessage"] = FinalResult.Message;
                return RedirectToPage();
            }
                var PayResult = _cartService.Pay(userId, FinalCart.PhoneNumber, FinalCart.Address);
            if (PayResult.Status != OperationResultStatus.Success)
            { 
                TempData["ErrorMessage"] = PayResult.Message;
              return RedirectToPage(); 
             }
            return RedirectToPage("SuccessPayment");
        }
      
        

        
       
    }
}
