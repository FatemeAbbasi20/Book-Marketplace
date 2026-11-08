using Esther_Shop.CoreLayer.Dtos.ArticleComments;
using Esther_Shop.CoreLayer.Dtos.Comments;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.DataLayer.Context;
using Esther_Shop.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Esther_Shop.CoreLayer.Services.ArticleComment
{
    public class ArticleCommentService : IArticleCommentService
    {
        private readonly BlogContext _context;

        public ArticleCommentService(BlogContext context)
        {
            _context = context;
        }
        public OperationResult CreateArticleComment(CreateArticleCommentsDto Command)
        {
            var Comment = new DataLayer.Entities.ArticleComment()
            {
                Text = Command.Text,
                ArticleId = Command.ArticleId,
                UserId = Command.UserId
            };
            _context.ArticleComments.Add(Comment);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<ArticleCommentsDto> GetArticleComments(int ArticleId)
        {
            return _context.ArticleComments.Include(p => p.User).Where(w => w.ArticleId == ArticleId).Select(Comment => new ArticleCommentsDto()
            {
                Text = Comment.Text,
                ArticleId = Comment.ArticleId,
                UserFullname =Comment.User.FullName,
                CommentId = Comment.Id,
                CreationDate = Comment.CreationDate
            }).ToList();

        }
    }
}
