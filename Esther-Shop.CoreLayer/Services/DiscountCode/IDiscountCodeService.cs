using Esther_Shop.CoreLayer.Dtos.DiscountCode;
using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.DiscountCodes
{
    public interface IDiscountCodeService
    {
        OperationResult CreateDiscountCode(CreateDiscountCodeDto Command);
        OperationResult EditDiscountCode(EditDiscountCodeDto Command);
        DiscountCodeDto GetDiscountById(int id);
        List<DiscountCodeDto> GetAllDiscountCode();
    }
}
