using Esther_Shop.CoreLayer.Dtos.Categoris;
using Esther_Shop.CoreLayer.Dtos.Posts;
using Esther_Shop.CoreLayer.Dtos.Products;
using Esther_Shop.CoreLayer.Mappers;
using Esther_Shop.CoreLayer.Services.FileManager;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly BlogContext _context;
        private readonly IFileManager _fileManager;

        public ProductService(BlogContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public OperationResult CreateProduct(CreateProductDto Command)
        {
            if (Command.MainImageFile == null)
                return OperationResult.Error();
            var product = ProductMapper.MapCreateDtoToProduct(Command);
            product.MainImageName = _fileManager.SaveFileAndReturnName(Command.MainImageFile, Directions.ProductImage);
            if (IsSlugExist(Command.Slug))
            {
                return OperationResult.Error("Slug is existed");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            if (Command.GalleryImages != null)
            {
                foreach (var image in Command.GalleryImages)
                {
                    var imageName = _fileManager.SaveFileAndReturnName(image, Directions.GalleryProductImage);

                    _context.ProductImages.Add(new DataLayer.Entities.ProductImage()
                    {
                        ProductId = product.Id,
                        ImageName = imageName,
                        IsMain = false
                    });
                }
            }
            return OperationResult.Success();
        }

        public OperationResult EditProduct(EditProductDto Command)
        {
            var product = _context.Products.Include(f => f.ProductImages).FirstOrDefault(p => p.Id == Command.ProductId);
            if (product == null)
            {
                return OperationResult.NotFound();
            }
            if (product.Slug != Command.Slug.ToSlug())
                if (IsSlugExist(Command.Slug))
                {
                    return OperationResult.Error("Slug is existed");
                }
            var oldImage = product.MainImageName;
            if (Command.MainImageFile != null)
            {
                _fileManager.DeleteFile(oldImage, Directions.ProductImage);
                product.MainImageName = _fileManager.SaveFileAndReturnName(Command.MainImageFile, Directions.ProductImage);
            }
            if (Command.GalleryImages != null)
            {
                foreach (var image in Command.GalleryImages)
                {
                    var imageName = _fileManager.SaveFileAndReturnName(image, Directions.GalleryProductImage);

                    product.ProductImages.Add(new DataLayer.Entities.ProductImage()
                    {
                        ImageName = imageName
                    });
                }
            }
            ProductMapper.MapEditDtoToProduct(Command, product);
            _context.SaveChanges();
            return OperationResult.Success();
        }


        public ProductDto GetProductById(int PostId)
        {
            var product = _context.Products.Include(c => c.Category).Include(c => c.SubCategory).Include(m=>m.ProductImages).FirstOrDefault(y => y.Id == PostId);
            if (product == null)
                return null;
            return ProductMapper.MapToProductDto(product);
        }

        public ProductDto GetProductBySlug(string Slug)
        {
            var product = _context.Products.Include(c => c.Category).Include(c => c.SubCategory).FirstOrDefault(y => y.Slug == Slug);
            if (product == null)
                return null;
            return ProductMapper.MapToProductDto(product);
        }


        public ProductFilterDto GetProductByFilter(ProductFilterParams filterParams)
        {
            var result = _context.Products.Include(c => c.Category).Include(c => c.SubCategory).OrderByDescending(p => p.CreationDate).AsQueryable();
            if (!String.IsNullOrWhiteSpace(filterParams.CategorySlug))
                result = result.Where(t => t.Category.Slug == filterParams.CategorySlug || t.SubCategory.Slug == filterParams.CategorySlug);
            if (!String.IsNullOrWhiteSpace(filterParams.Title))
                result = result.Where(t => t.Title.Contains( filterParams.Title));
            var skip = (filterParams.PageId - 1) * filterParams.Take;
            var model = new ProductFilterDto()
            {
                Products = result.Skip(skip).Take(filterParams.Take).Select(Product => ProductMapper.MapToProductDto(Product)).ToList(),
                FilterParams = filterParams
            };
            model.GeneratePaging(result, filterParams.Take, filterParams.PageId);
            return model;
        }


        public bool IsSlugExist(string Slug)
        {
            return _context.Products.Any(f => f.Slug == Slug.ToSlug()); 

        }


        OperationResult IProductService.DeleteProductImage(int imageId)
        {
            var image = _context.ProductImages.FirstOrDefault(y => y.Id == imageId);
            if (image == null)
                return OperationResult.NotFound();
            _fileManager.DeleteFile(image.ImageName, Directions.GalleryProductImage);
            _context.ProductImages.Remove(image);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<ProductDto> GetRelatedProducts(int CategoryId)
        {
            return _context.Products.Where(p => p.CategoryId == CategoryId || p.SubCategoryId == CategoryId).Take(5).OrderByDescending(e => e.CreationDate).Select(product => ProductMapper.MapToProductDto(product)).ToList();
        }

        public ProductDto GetPreProduct(int Id)
        {
            var product = _context.Products.FirstOrDefault(d => d.Id < Id);
            if (product == null)
                return null;
            return ProductMapper.MapToProductDto(product);
        }

        public ProductDto GetNextProduct(int Id)
        {
            var product = _context.Products.FirstOrDefault(d => d.Id > Id);
            if (product == null)
                return null;
            return ProductMapper.MapToProductDto(product);
        }

        public void IncreaseVisit(int ProductId)
        {
           var product= _context.Products.First(p => p.Id == ProductId);
            product.Visit +=1;
            _context.SaveChanges();
        }

        public ProductSearchDto GetProductBySearch(ProductSearchParams SearchParams)
        {
            var result = _context.Products.AsNoTracking().Include(c => c.Category).Include(p => p.SubCategory).AsQueryable();
            if (!string.IsNullOrWhiteSpace(SearchParams.Title))
            {
                result=result.Where(p=>p.Title.Contains(SearchParams.Title));
            }
            if (SearchParams.CategorySlug?.Any()==true)
            {
                result = result.Where(p =>SearchParams.CategorySlug.Contains(p.Category.Slug)||SearchParams.CategorySlug.Contains(p.SubCategory.Slug));
            }
            if (SearchParams.Author?.Any() == true)
            {
                result = result.Where(p => SearchParams.Author.Contains(p.Author));
            }
            if (SearchParams.Publisher?.Any() == true)
            {
                result = result.Where(p => SearchParams.Publisher.Contains(p.Publisher));
            }
            if (SearchParams.MaxPrice.HasValue)
            {
                result = result.Where(p => p.Price<=SearchParams.MaxPrice.Value);
            }
            if (SearchParams.MinPrice.HasValue)
            {
                result = result.Where(p => p.Price>= SearchParams.MinPrice.Value);
            }

            result = SearchParams.OrderBy switch
            {
                ProductOrderBy.Cheapest=>result.OrderBy(p=>p.Price),
                ProductOrderBy.MostExpensive=>result.OrderByDescending(e=>e.Price),
                ProductOrderBy.Newest => result.OrderByDescending(e => e.CreationDate),
                ProductOrderBy.Popular => result.OrderByDescending(e => e.Visit),
               ProductOrderBy.Title=> result.OrderBy(e => e.Title),
               _=>result.OrderByDescending(p=>p.CreationDate)

            };
            var skip = (SearchParams.CurrentPage - 1) * SearchParams.Take;
            var model = new ProductSearchDto()
            {
                Products = result.Skip(skip).Take(SearchParams.Take).Select(Product => ProductMapper.MapToProductDto(Product)).ToList(),
                SearchParams= SearchParams
            };
            model.GeneratePaging(result,SearchParams.Take,SearchParams.CurrentPage);
            return model;


        }

        public ProductSearchDataDto GetSearchData()
        {
            var categories = _context.Categories.Where(d => d.ParentId == null).OrderByDescending(d => d.CreationDate).Select(categories => new CategorySearchDto()
            {
                Id = categories.Id, Title = categories.Title, Slug = categories.Slug
            }).ToList();
            var author = _context.Products.Where(e => e.Author != null).Select(e => e.Author!).Distinct().ToList();
            var publisher = _context.Products.Where(e => e.Publisher != null).Select(e => e.Publisher!).Distinct().ToList();



            return new ProductSearchDataDto()
            {
                Categories= categories,
                Author=author,
                Publisher=publisher
            };
        }
    }
}