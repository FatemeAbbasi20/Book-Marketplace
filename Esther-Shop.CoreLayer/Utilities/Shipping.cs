using Shop.DataLayer.Entities;

namespace Esther_Shop.CoreLayer.Utilities
{
    public class Shipping
    {
        public static int GetShippingPrice(ShippingMethod method)
        {
            switch (method)
            {
                case ShippingMethod.Post:
                    return 200000;
                case ShippingMethod.Peyk:
                    return 400000;
                case ShippingMethod.Tipax:
                    return 300000;
                default: return 200000;
            }
        }
    }

    }
