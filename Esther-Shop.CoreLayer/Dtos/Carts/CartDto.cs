using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Carts
{
    public class CartDto
    {
        public int Id { get; set; }
        public bool IsFinal { get; set; }
        public int UserId { get; set; }
        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
        public decimal TotalPrice { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public int ShippingPrice { get; set; }
        public decimal FinalPrice { get; set; } 
        public int? DiscountCodeId { get; set; }
        public string? DiscountCodeTitle { get; set; }
        public decimal DiscountPercent { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Notes { get; set; }
    }
}
