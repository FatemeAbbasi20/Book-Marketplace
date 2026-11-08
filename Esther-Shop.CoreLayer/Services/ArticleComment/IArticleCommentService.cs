using Esther_Shop.CoreLayer.Dtos.ArticleComments;
using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.ArticleComment
{
    public interface IArticleCommentService
    {
        OperationResult CreateArticleComment(CreateArticleCommentsDto Command);
        List<ArticleCommentsDto>GetArticleComments(int ArticleId);

    }
}
