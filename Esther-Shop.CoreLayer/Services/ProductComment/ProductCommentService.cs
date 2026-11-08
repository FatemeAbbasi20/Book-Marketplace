using Esther_Shop.CoreLayer.Dtos.Comments;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.Comment
{
    public class ProductCommentService : IProductCommentService
    {
        private readonly BlogContext _context;

        public ProductCommentService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreateProductComment(CreateProductCommentDto Command)
        {
            var Comment = new ProductComment() { 
                Text=Command.Text,ProductId=Command.ProductId,UserId=Command.UserId
            };
            _context.ProductComments.Add(Comment);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<ProductCommentDto> GetProductComments(int ProductId)
        {
         return _context.ProductComments.Include(p=>p.User).Where(w=>w.ProductId==ProductId).Select(Comment=>new ProductCommentDto()
         {
             Text=Comment.Text,
             ProductId=Comment.ProductId,
             UserFullName=Comment.User.FullName,
             CommentId=Comment.Id,
             CreationDate=Comment.CreationDate
         }).ToList();
        }
    }
}
