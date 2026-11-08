using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.ArticleComments
{
    public class ArticleCommentsDto
    {
        public DateTime CreationDate { get; set; }
        public int CommentId { get; set; }
        public string Text { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public string UserFullname { get; set; }= string.Empty;
    }
}
