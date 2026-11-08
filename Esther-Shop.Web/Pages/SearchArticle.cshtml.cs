using Esther_Shop.CoreLayer.Dtos.ArticleComments;
using Esther_Shop.CoreLayer.Dtos.Articles;
using Esther_Shop.CoreLayer.Services.Article;
using Esther_Shop.CoreLayer.Services.ArticleComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Esther_Shop.Web.Pages
{
    public class SearchBlogModel : PageModel
    {
        private readonly IArticleService _articleService;


        public SearchBlogModel(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public ArticleFilterDto Search { get; set; }
        public List<ArticleDto> LatestArticles { get; set; }

        public void OnGet(int pageId, string CategorySlug="",string Title="")
        {
            Search=_articleService.GetArticleByFilter(new ArticleFilterParams() { Take=2,Title=Title,CategorySlug=CategorySlug,PageId=pageId});
            LatestArticles = _articleService.GetLatestArticles();
        }
        public IActionResult OnGetPagination(int pageId, string CategorySlug = "", string Title = "")
        {
            Search = _articleService.GetArticleByFilter(new ArticleFilterParams() { Take = 2, Title = Title, CategorySlug = CategorySlug, PageId = pageId });
            return Partial("_SearchArticleView",Search);
        }
    }
}
