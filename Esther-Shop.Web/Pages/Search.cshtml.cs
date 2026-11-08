using Esther_Shop.CoreLayer.Dtos.Products;
using Esther_Shop.CoreLayer.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Esther_Shop.Web.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IProductService _productService;

        public SearchModel(IProductService productService)
        {
            _productService = productService;
        }
        public ProductSearchDto Search { get; set; }
        public ProductSearchDataDto SearchData { get; set; }
        [BindProperty(SupportsGet =true)]
        public ProductSearchParams Params { get; set; }

        public void OnGet()
        {
            Params.Take = 2;
            SearchData = _productService.GetSearchData();
            Search = _productService.GetProductBySearch(Params);
           
        }
        public IActionResult OnGetPagination( )
        {

            SearchData = _productService.GetSearchData();
            Search = _productService.GetProductBySearch(Params);

            return Partial("_SearchView",Search);
        }

    }
}
 