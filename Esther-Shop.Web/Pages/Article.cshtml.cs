using Esther_Shop.CoreLayer.Dtos.ArticleComments;
using Esther_Shop.CoreLayer.Dtos.Articles;
using Esther_Shop.CoreLayer.Services.Article;
using Esther_Shop.CoreLayer.Services.ArticleCategory;
using Esther_Shop.CoreLayer.Services.ArticleComment;
using Esther_Shop.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Esther_Shop.Web.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IArticleService _articleService;
        private  readonly IArticleCommentService _commentService;

        public ArticleModel(IArticleService articleService, IArticleCommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }
        public ArticleDto Article { get; set; }
        public List<ArticleCommentsDto> Comments { get; set; }
        public List<ArticleDto> RelatedArticles { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Text { get; set; }
        [BindProperty]
        [Required]
        public int ArticleId { get; set; }

        public IActionResult OnGet(string slug)
        {
           Article= _articleService.GetArticleBySlug(slug);
            Comments = _commentService.GetArticleComments(Article.ArticleId);
            RelatedArticles=_articleService.GetRelatedArticles(Article.ArticleId);
            if (Article == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost(string slug)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Article", new {slug});
            }
            if (!ModelState.IsValid)
            {
                Article = _articleService.GetArticleBySlug(slug);
                Comments = _commentService.GetArticleComments(Article.ArticleId);
                RelatedArticles = _articleService.GetRelatedArticles(Article.ArticleId);
                return Page();
            }
            _commentService.CreateArticleComment(new CreateArticleCommentsDto() { Text = Text, UserId = User.GetUserId(), ArticleId = ArticleId });
            return RedirectToPage("Article", new { slug });
        }


    }
}
