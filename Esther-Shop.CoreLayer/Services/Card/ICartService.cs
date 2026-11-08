using Esther_Shop.CoreLayer.Dtos.Carts;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.Card
{
    public interface ICartService
    {
        CartDto GetOrCreateCart(int UserId);
        OperationResult AddToCart(int UserId,int Count,int ProductId);
        CartDto CreateCart(int UserId);
        OperationResult RemoveCartItem(int UserId,int CartItemId);
        OperationResult UpdateCartItem(int UserId,int CartItemId,int NewCount);
        OperationResult Finalize(int UserId,FinalizeCartDto finalizeDto);
        OperationResult ApplyDiscount(int UserId, string DiscountTitle);
        OperationResult Pay(int UserId,string Mobile,string Address );
        CartDto GetCart(int UserId);

    }
}
