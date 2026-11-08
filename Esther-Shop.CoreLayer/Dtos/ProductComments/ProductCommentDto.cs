using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Comments
{
    public class ProductCommentDto
    {
        public int CommentId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Text { get; set; } = string.Empty;

        public int ProductId { get; set; }

        public string UserFullName { get; set; }= string.Empty;


    }
}
