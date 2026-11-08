using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Utilities
{
    public class BasePagination
    {
        public int EntityCount { get; set; }
        public int PageCount { get; set; }
        public int Take { get; set; }
        public int CurrentPage { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public void GeneratePaging(IQueryable<object>data,int take,int currentPage)
        {
            var entityCount = data.Count();
            var pageCount = (int)Math.Ceiling(entityCount / (double)take);
            Take = take;
            CurrentPage= currentPage;
            EntityCount = entityCount;
            PageCount = pageCount;
            EndPage= currentPage+5 >PageCount? PageCount : currentPage + 5;
            StartPage = currentPage -4 <=0 ? 1 : currentPage -4;
        }
    }
       
}
