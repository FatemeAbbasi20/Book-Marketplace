using Esther_Shop.CoreLayer.Dtos.Categoris;
using Esther_Shop.CoreLayer.Dtos.Posts;
using Esther_Shop.CoreLayer.Dtos.Products;
using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.Product
{
    public interface IProductService
    {
        OperationResult CreateProduct(CreateProductDto Command);
        OperationResult EditProduct(EditProductDto Command);
        ProductDto GetProductById(int PostId);
        ProductDto GetProductBySlug(string Slug);
        bool IsSlugExist(string Slug);
        ProductFilterDto GetProductByFilter(ProductFilterParams filterParams);
        OperationResult DeleteProductImage(int imageId);
        List<ProductDto> GetRelatedProducts(int CategoryId);
        ProductDto GetPreProduct(int Id);
        ProductDto GetNextProduct(int Id);
        void IncreaseVisit(int ProductId);
        ProductSearchDto GetProductBySearch(ProductSearchParams SearchParams);
        ProductSearchDataDto GetSearchData();
    }
}
