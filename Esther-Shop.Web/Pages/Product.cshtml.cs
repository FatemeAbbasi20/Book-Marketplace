using Esther_Shop.CoreLayer.Dtos.Comments;
using Esther_Shop.CoreLayer.Dtos.Posts;
using Esther_Shop.CoreLayer.Services.Comment;
using Esther_Shop.CoreLayer.Services.Product;
using Esther_Shop.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Esther_Shop.Web.Pages.Shared
{
    public class ProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductCommentService _commentService;

        public ProductModel(IProductService productService, IProductCommentService commentService)
        {
            _productService = productService;
            _commentService = commentService;
        }
        public ProductDto Product { get; set; }
        public List <ProductCommentDto> Comments { get; set; }
        public List<ProductDto> RelatedProducts { get; set; }
        [Required]
        [BindProperty]
        public int ProductId { get; set; }
        [Required]
        [BindProperty]
        public string Text { get; set; } = string.Empty;
        public IActionResult OnGet(string Slug)
        {
            Product = _productService.GetProductBySlug(Slug);
            Comments = _commentService.GetProductComments(Product.ProductId);
            RelatedProducts=_productService.GetRelatedProducts(Product.SubCategoryId??Product.CategoryId);
            _productService.IncreaseVisit(Product.ProductId);
            if (Product == null)
                return NotFound();
            return Page();
        }
        public IActionResult OnPost(string Slug)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("Product", new {Slug});
            }
            if (!ModelState.IsValid)
            {
                Product = _productService.GetProductBySlug(Slug);
                Comments = _commentService.GetProductComments(ProductId);
                RelatedProducts = _productService.GetRelatedProducts(Product.SubCategoryId ?? Product.CategoryId);
                return Page();
            }
            _commentService.CreateProductComment(new CreateProductCommentDto()
            {
                Text= Text, ProductId= ProductId,UserId=User.GetUserId()
            });
           
            return RedirectToPage("Product", new { Slug });
        }
    }
}
