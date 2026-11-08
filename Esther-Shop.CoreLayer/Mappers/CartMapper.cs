using Esther_Shop.CoreLayer.Dtos.Carts;
using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Mappers
{
    public  class CartMapper
    {
        public static CartDto MapToDto(Cart cart)
        {
            return new CartDto()
            { 
                UserId = cart.UserId,
                IsFinal = cart.IsFinal,
                ShippingMethod = cart.ShippingMethod,
                ShippingPrice = cart.ShippingPrice,
                TotalPrice = cart.TotalPrice,
                City = cart.City,
                FullName = cart.FullName,
                Address = cart.Address,
                PhoneNumber = cart.PhoneNumber,
                Notes = cart.Notes,
                DiscountCodeId = cart.DiscountCodeId,
                Items = cart.Items.Select(item => new CartItemDto()
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    ProductImage = item.Product?.Title ?? "نامشخص",
                    ProductTitle = item.Product?.MainImageName ?? "",
                    Count = item.Count,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.TotalPrice,
                    CartId = item.CartId
                }).ToList(),
                Id = cart.Id,
                FinalPrice= cart.TotalPrice-(cart.TotalPrice*( cart.DiscountCode?.Precent??0/100))+cart.ShippingPrice
            };

        }

    }
}
