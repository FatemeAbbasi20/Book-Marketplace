namespace Esther_Shop.CoreLayer.Dtos.Carts
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int CartId { get; set; }

        public int Count { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductTitle { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;


    }
}
