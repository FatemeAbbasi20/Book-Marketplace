using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Comments
{
    public class CreateProductCommentDto
    {
        public string Text { get; set; } = string.Empty;

        public int ProductId { get; set; }

        public int UserId { get; set; }


    }
}
