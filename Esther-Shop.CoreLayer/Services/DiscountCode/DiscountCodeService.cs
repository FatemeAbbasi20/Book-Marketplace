using Esther_Shop.CoreLayer.Dtos.DiscountCode;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.DiscountCodes
{
    public class DiscountCodeService : IDiscountCodeService
    {
        private readonly BlogContext _context;

        public DiscountCodeService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreateDiscountCode(CreateDiscountCodeDto Command)
        {
            var discount=new DataLayer.Entities.DiscountCode()
            {
                Code=Command.Code,
                Precent=Command.Precent,
                IsActive=Command.IsActive,
                ExpireTime=Command.ExpireTime
            };
            //if (Command.Precent > 100)
            //{
            //    return OperationResult.Error("درصد را بزرگتر از 100 وارد کردید");
            //}
            var result = _context.DiscountCodes.Add(discount);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditDiscountCode(EditDiscountCodeDto Command)
        {
            var discount = _context.DiscountCodes.FirstOrDefault(d => d.Id == Command.Id);
            if (discount == null) 
                return OperationResult.NotFound();
            discount.Code= Command.Code;
          discount.Precent = Command.Precent;
          discount.IsActive = Command.IsActive ;
           discount.ExpireTime =Command.ExpireTime;
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<DiscountCodeDto> GetAllDiscountCode()
        {
            return _context.DiscountCodes.Select(discount=>new DiscountCodeDto()
            {
                Code=discount.Code,ExpireTime=discount.ExpireTime,Precent=discount.Precent,IsActive=discount.IsActive
            }).ToList();
        }

        public DiscountCodeDto GetDiscountById(int id)
        {
            var discount = _context.DiscountCodes.FirstOrDefault(d => d.Id == id);
            if (discount == null)
            {
                return null;
            }
            return new DiscountCodeDto()
            {
                Code = discount.Code,
                ExpireTime = discount.ExpireTime,
                Precent = discount.Precent,
                IsActive = discount.IsActive
            };

        
        }
    }
}
