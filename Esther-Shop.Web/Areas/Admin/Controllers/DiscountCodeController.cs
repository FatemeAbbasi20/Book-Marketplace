using Esther_Shop.CoreLayer.Dtos.DiscountCode;
using Esther_Shop.CoreLayer.Services.DiscountCodes;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.Web.Areas.Admin.Models.DiscountCode;
using Microsoft.AspNetCore.Mvc;

namespace Esther_Shop.Web.Areas.Admin.Controllers
{
    public class DiscountCodeController : AdminBaseController
    {
        private readonly IDiscountCodeService _discountService;

        public DiscountCodeController(IDiscountCodeService discountService)
        {
            _discountService = discountService;
        }

        public IActionResult Index()
        {
            return View(_discountService.GetAllDiscountCode());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDiscountCodeDto createViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
                var result = _discountService.CreateDiscountCode(new CreateDiscountCodeDto()
            {
                Code=createViewModel.Code,
                IsActive=createViewModel.IsActive,
                ExpireTime=createViewModel.ExpireTime,
                Precent=createViewModel.Precent
            });
            return RedirectAndShowAlert(result, RedirectToAction("Index"));
        }
        public IActionResult Edit(int id)
        {
            var discountCode = _discountService.GetDiscountById(id);
            if (discountCode == null)
            {
                return NotFound();
            }
            var model = new EditDiscountCodeModel()
            {
                Code=discountCode.Code,IsActive=discountCode.IsActive,
                ExpireTime =discountCode.ExpireTime,Precent=discountCode.Precent,Id=discountCode.Id
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id,EditDiscountCodeModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result= _discountService.EditDiscountCode( new EditDiscountCodeDto(){
                Code=editViewModel.Code,IsActive=editViewModel.IsActive,
                ExpireTime=editViewModel.ExpireTime, Precent=editViewModel.Precent, Id=editViewModel.Id
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View(editViewModel);
            }
            return RedirectToAction("Index");

        }
    }
}
