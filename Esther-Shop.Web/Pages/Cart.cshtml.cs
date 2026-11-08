using Esther_Shop.CoreLayer.Dtos.Carts;
using Esther_Shop.CoreLayer.Services.Card;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.Web.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace Esther_Shop.Web.Pages
{
    public class CartModel : PageModel
    {
        private readonly ICartService _cartService;

        public CartModel(ICartService cartService)
        {
            _cartService = cartService;
        }
        public  CartDto Cart { get; set; }
        [BindProperty]
        public string DiscountTitle { get; set; }
        [BindProperty]
        public int NewCount { get; set; }
        [BindProperty]
        public int CartItemId { get; set; }
        public IActionResult OnGet()
        {
            var userId = User.GetUserId();
          Cart=  _cartService.GetOrCreateCart(userId);
            return Page();
        }
        public IActionResult OnPostAdd([FromBody]AddToCartModel model)
        {
            var userId = User.GetUserId();
            var result=_cartService.AddToCart(userId,model.Count,model.ProductId);
            if (result.Status != OperationResultStatus.Success)
            {
                return new OkObjectResult(new {success=false, message=result.Message });
            }
            else
            {
                return new OkObjectResult(new { success = true, message = result.Message });
            }
   
        }

        public IActionResult OnPostUpdate()
        {
            var userId = User.GetUserId();
            var result = _cartService.UpdateCartItem(userId,CartItemId, NewCount);
            if (result.Status != OperationResultStatus.Success)
              {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToPage();
            }
            return Page();
        }

        public IActionResult OnPostRemove() 
        {
            var userId = User.GetUserId();
            var result = _cartService.RemoveCartItem(userId,CartItemId);
            if (result.Status != OperationResultStatus.Success)
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToPage();
            }
            return Page();
        }
        public IActionResult OnPostApplyDiscount()
        {
            var userId = User.GetUserId();

            var result = _cartService.ApplyDiscount(userId, DiscountTitle);
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(DiscountTitle), result.Message);
                Cart = _cartService.GetCart(userId);
                return Page();
            }
            TempData["ErrorMessage"] = result.Message;
            return RedirectToPage();
        }
    
           
        


      


    }
}
