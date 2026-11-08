using Esther_Shop.CoreLayer.Dtos.Posts;
using Esther_Shop.CoreLayer.Dtos.Products;
using Esther_Shop.CoreLayer.Services.FileManager;
using Esther_Shop.CoreLayer.Services.Product;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.Web.Areas.Admin.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Esther_Shop.Web.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IProductService _productService;
     
        public ProductController(IProductService productService)
        {
            _productService = productService;
         
        }

        public IActionResult Index(int pageId = 1, string categorySlug = "", string title = "")
        {
            var model = _productService.GetProductByFilter(new ProductFilterParams()
            {
                Take = 1, PageId = pageId, CategorySlug = categorySlug, Title = title
            });
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateProductViewModel createViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(createViewModel);
            }
            var result = _productService.CreateProduct(new CreateProductDto()
            {
                Description=createViewModel.Description,MainImageFile=createViewModel.MainImageFile,Slug=createViewModel.Slug,
                 Title=createViewModel.Title,MetaDescription=createViewModel.MetaDescription,
                 IsSpecial=createViewModel.IsSpecial,CategoryId=createViewModel.CategoryId,
                SubCategoryId=createViewModel.SubCategoryId==0?null:createViewModel.SubCategoryId,Price=createViewModel.Price,
                GalleryImages=createViewModel.GalleryImages,DiscountPrecent=createViewModel.DiscountPrecent
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(createViewModel.Slug),result.Message);
                return View(createViewModel);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id )
        {
            var product=_productService.GetProductById(id);
            if (product == null)
                return RedirectToAction("Index");
            var model = new EditProductViewModel()
            {
              Title = product.Title,Description=product.Description,Slug=product.Slug,
              MetaDescription=product.MetaDescription,
              IsSpecial=product.IsSpecial,CategoryId=product.CategoryId,SubCategoryId=product.SubCategoryId,
              Price=product.Price,DiscountPrecent = product.DiscountPrecent,IsInSlider=product.IsInSlider,
              Author=product.Author,Trenslator=product.Trenslator,Publisher=product.Publisher,Stock=product.Stock,
              ProductImages=product.ProductImages
              
            };
            return View(model);
        }            
        [HttpPost]
        public IActionResult Edit( EditProductViewModel EditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(EditViewModel);
            }
            var result = _productService.EditProduct(new EditProductDto()
            {
                Description = EditViewModel.Description,
                Slug = EditViewModel.Slug,
                Title = EditViewModel.Title,
                MainImageFile = EditViewModel.MainImageFile,
                MetaDescription = EditViewModel.MetaDescription,
                IsSpecial = EditViewModel.IsSpecial,
                CategoryId = EditViewModel.CategoryId,
                SubCategoryId = EditViewModel.SubCategoryId,
                Price = EditViewModel.Price,
                GalleryImages= EditViewModel.GalleryImages,
                DiscountPrecent = EditViewModel.DiscountPrecent,
                ProductId=EditViewModel.Id,
                Author=EditViewModel.Author,
                Publisher=EditViewModel.Publisher,
                Stock =EditViewModel.Stock,
               IsInSlider=EditViewModel.IsInSlider,
               Trenslator=EditViewModel.Trenslator
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError((EditViewModel.Slug), (result.Message));
                return View(EditViewModel);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteGalleryImages(int id,int productId)
        {
          var result=_productService.DeleteProductImage(id);
            if(result.Status==OperationResultStatus.NotFound)
            {
               TempData["ErrorMessage"]=" تصویر مورد نظر یافت نشد";
               return RedirectToAction("Edit", new {id= productId });
            }
            return RedirectToAction("Edit", new { id = productId });
        }
    }
}
