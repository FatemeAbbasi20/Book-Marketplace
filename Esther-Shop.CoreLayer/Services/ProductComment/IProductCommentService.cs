using Esther_Shop.CoreLayer.Dtos.Comments;
using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.Comment
{
    public interface IProductCommentService
    {
        OperationResult CreateProductComment(CreateProductCommentDto Command);
        List<ProductCommentDto> GetProductComments(int ProductId);
    }
}
