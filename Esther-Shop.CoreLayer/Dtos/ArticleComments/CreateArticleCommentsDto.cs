using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.ArticleComments
{
    public class CreateArticleCommentsDto
    {
        public string Text { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int ArticleId { get; set; }
    }
}
