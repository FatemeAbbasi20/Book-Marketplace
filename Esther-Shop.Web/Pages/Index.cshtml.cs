using Esther_Shop.CoreLayer.Dtos;
using Esther_Shop.CoreLayer.Dtos.Products;
using Esther_Shop.CoreLayer.Services;
using Esther_Shop.CoreLayer.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Esther_Shop.Web.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMainPageService _minPageService;
        private readonly IProductService _productService;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IMainPageService minPageService, IProductService productService)
        {
            _logger = logger;
            _minPageService = minPageService;
            _productService = productService;
        }
        public MainPageDto PageData { get; set; }
        public void OnGet()
        {
            PageData = _minPageService.GetData();
        }
        public IActionResult OnGetNewestProducts(string slug)
        {
            var filterDto=_productService.GetProductByFilter(new ProductFilterParams()
            {
                CategorySlug= slug,PageId=1,Take=10
            });
            return Partial("_NewestProducts", filterDto);
        }
        public IActionResult OnGetProductModal(string Slug)
        {
            var Product=_productService.GetProductBySlug(Slug);
            if(Product==null)
            {
                return NotFound();
            }
            return Partial("_ProductModal",Product);

        }

    }  
}
