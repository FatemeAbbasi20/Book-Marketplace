using Esther_Shop.CoreLayer.Dtos.Carts;
using Esther_Shop.CoreLayer.Mappers;
using Esther_Shop.CoreLayer.Services.Product;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.Card
{
    public class CartService : ICartService
    {
        private readonly BlogContext _context;


        public CartService(BlogContext context )
        {
            _context = context;

        }

        public OperationResult AddToCart(int UserId, int Count, int ProductId)
        {
            if (Count <= 0) { return OperationResult.NotFound("تعداد نامعتبر"); }
           

            var cart = _context.Carts.Include(d=>d.Items).FirstOrDefault(f=>f.UserId== UserId&&!f.IsFinal);
            if (cart == null) 
            {
                cart = new Cart()
                {
                    UserId = UserId,
                    IsFinal = false,
                };
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }
            var product = _context.Products.Find(ProductId);
            if (product == null) { return OperationResult.NotFound("محصول یافت نشد"); }
            if (product.Stock < Count) { return OperationResult.Error("تعداد نامعتبر"); }
            var existentCartItem = _context.CartItems.FirstOrDefault(e => e.CartId == cart.Id && e.ProductId == ProductId);
            //var existentCartItem = cart.Items.FirstOrDefault(d=>d.ProductId==ProductId);
            
            if (existentCartItem != null)
            {
                var NewCount = Count + existentCartItem.Count;
                if (product.Stock < NewCount) { return OperationResult.Error("تعداد نامعتبر"); }
                existentCartItem.Count += Count;
                existentCartItem.UnitPrice = product.Price;
                existentCartItem.TotalPrice = product.Price *existentCartItem. Count;

            }
            else
            {
                 _context.CartItems.Add(new CartItem()
                //cart.Items.Add(new CartItem()
                {
                    ProductId = ProductId,
                    Count = Count,
                    CartId = cart.Id,
                    UnitPrice = product.Price,
                    TotalPrice = product.Price * Count
                });

            }
            //cart.TotalPrice=cart.Items.Sum(s=>s.TotalPrice);
            cart.TotalPrice = _context.CartItems.Where(s => s.CartId == cart.Id).Sum(s=>s.TotalPrice);
            _context.SaveChanges();
            return OperationResult.Success("محصول به سبد خرید شما اضافه شد");
        }

        public OperationResult ApplyDiscount(int UserId,string DiscountTitle)
        {
            var cart = _context.Carts.Include(f => f.Items).FirstOrDefault(d => d.UserId == UserId && !d.IsFinal);
            if (cart == null) { return OperationResult.NotFound("سبد خرید خالی است"); }
           var discount= _context.DiscountCodes.FirstOrDefault(d => d.Code == DiscountTitle);
            if (discount == null) { return OperationResult.Error("کد تخفیف نامعتبر است"); }
            if (discount.ExpireTime < DateTime.Now || !discount.IsActive) { return OperationResult.Error("کد تخفیف منضی شده است"); }
            cart.DiscountCodeId = discount.Id;
            _context.SaveChanges();
            return OperationResult.Success(" کد تخفیف اعمال شد");
        }

        public CartDto CreateCart(int UserId)
        {
            var cart = new Cart()
            {
                UserId = UserId,
                IsFinal = false,
                Items = new List<CartItem>(),
                TotalPrice = 0,
                ShippingPrice = 20000,
                ShippingMethod = ShippingMethod.Post

            };
            _context.Carts.Add(cart);
            return CartMapper.MapToDto(cart);
        }

        public OperationResult Finalize(int UserId, FinalizeCartDto finalizeDto)
        {
            var cart = _context.Carts.Include(f => f.Items).FirstOrDefault(d => d.UserId == UserId && !d.IsFinal );
            if (cart == null) {return OperationResult.NotFound("سبد خرید خالی است");}
            if (!cart.Items.Any()) { return OperationResult.NotFound("سبد خرید خالی است"); }
            cart.PhoneNumber = finalizeDto.PhoneNumber; 
            cart.City = finalizeDto.City; 
            cart.Address = finalizeDto.Address; 
            cart.FullName = finalizeDto.FullName;
            cart.ShippingMethod= finalizeDto.ShippingMethod;
            cart.ShippingPrice= @Shipping.GetShippingPrice(finalizeDto.ShippingMethod);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public CartDto GetCart(int UserId)
        {
            var cart = _context.Carts.Include(f => f.Items).ThenInclude(f => f.Product).FirstOrDefault(f => f.UserId == UserId && !f.IsFinal);
            if (cart == null) { return null; }
            return CartMapper.MapToDto(cart);

        }

        public CartDto GetOrCreateCart(int UserId)
        {
            var cart=_context.Carts.Include(f=>f.Items).ThenInclude(f=>f.Product).FirstOrDefault(f=>f.UserId== UserId && !f.IsFinal);
            if (cart == null||!cart.Items.Any())
            {
                cart = new Cart()
                {
                    UserId = UserId,
                    IsFinal = false,
                    TotalPrice = 0,
                    ShippingPrice = 20000,
                    ShippingMethod = ShippingMethod.Post
                };
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }
                return CartMapper.MapToDto(cart);
            
        }

        public OperationResult Pay(int UserId , string Mobile,string Address)
        {
            var cart = _context.Carts.Include(f => f.Items).FirstOrDefault(d => d.UserId == UserId && !d.IsFinal);
            if (cart == null) { return OperationResult.NotFound("سبد خرید خالی است"); }
            if (!cart.Items.Any()) { return OperationResult.NotFound("سبد خرید خالی است"); }
            cart.PhoneNumber = Mobile;
            cart.Address=Address;
            cart.IsFinal = true;
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult RemoveCartItem(int UserId,int CartItemId)
        {
            var item = _context.CartItems.Include(d=>d.Cart).Where(e=>e.Cart.UserId==UserId).FirstOrDefault(C => C.Id == CartItemId);
            if (item == null) { OperationResult.NotFound(); }
            _context.CartItems.Remove(item);
            var cart = _context.Carts.Find(item.CartId);
            if (cart != null)
               { 
                cart.TotalPrice=_context.CartItems.Where(e=>e.CartId==cart.Id).Sum(x=>x.TotalPrice);
                _context.SaveChanges();
            }
            return OperationResult.Success();
        }

        public OperationResult UpdateCartItem(int UserId,int CartItemId, int NewCount)
        {
            if (NewCount <= 0) { return OperationResult.Error(); }
            var item = _context.CartItems.Include(d => d.Cart).Where(e => e.Cart.UserId == UserId).FirstOrDefault(C => C.Id == CartItemId);
            if (item == null) { OperationResult.NotFound(); }
            var product = _context.Products.Find(item.ProductId);
            if (NewCount > product.Stock) { OperationResult.Error("موجودی کافی نیست"); }
            item.Count = NewCount;
            item.UnitPrice = product.Price;
            item.TotalPrice = product.Price * NewCount;
            var cart = _context.Carts.FirstOrDefault(x => x.Id == item.CartId);
            cart.TotalPrice=_context.CartItems.Where(d=>d.CartId==cart.Id).Sum(s=>s.TotalPrice);
            _context.SaveChanges();
           return OperationResult.Success();

        }

 
        //public int GetShippingPrice(ShippingMethod method)
        //{
        //    switch (method)
        //    {
        //        case ShippingMethod.Post:
        //             return 200000;
        //        case ShippingMethod.Peyk:
        //            return 400000;
        //        case ShippingMethod.Tipax:
        //            return 300000;
        //        default:return 200000;
        //    }
        //}
    }
}
