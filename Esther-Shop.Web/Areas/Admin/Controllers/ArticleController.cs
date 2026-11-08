using Esther_Shop.CoreLayer.Dtos.Articles;
using Esther_Shop.CoreLayer.Dtos.Posts;
using Esther_Shop.CoreLayer.Services.Article;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.Web.Areas.Admin.Models.Article;
using Esther_Shop.Web.Areas.Admin.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Esther_Shop.Web.Areas.Admin.Controllers
{
    public class ArticleController : AdminBaseController
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index(int pageId = 1, string categorySlug = "", string title = "")
        {
            var model = _articleService.GetArticleByFilter(new ArticleFilterParams()
            {
                Take = 1,
                PageId = pageId,
                CategorySlug = categorySlug,
                Title = title
            });
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateArticleViewModel createViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createViewModel);
            }
            var result = _articleService.CreateArticle(new CreateArticleDto()
            {
                Description = createViewModel.Description,
                ImageFile = createViewModel.ImageFile,
                Slug = createViewModel.Slug,
                Title = createViewModel.Title,
                MetaDescription = createViewModel.MetaDescription,
                IsPublish = createViewModel.IsPublish,
                UserId = User.GetUserId()
             });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(createViewModel.Slug), result.Message);
                return View(createViewModel);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var product = _articleService.GetArticleById(id);
            if (product == null)
                return RedirectToAction("Index");
            var model = new EditArticleViewModel()
            {
                Title = product.Title,
                Description = product.Description,
                Slug = product.Slug,
                MetaDescription = product.MetaDescription,
                 UserId= User.GetUserId(),
                IsPublish= product.IsPublish
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditArticleViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            var result = _articleService.EditArticle(new EditArticleDto()
            {
                Description = editViewModel.Description,
                Slug = editViewModel.Slug,
                Title = editViewModel.Title,
                ImageFile = editViewModel.ImageFile,
                MetaDescription = editViewModel.MetaDescription,
                IsPublish= editViewModel.IsPublish,
               UserId = User.GetUserId(),
               ArticleId = id
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError((editViewModel.Slug), (result.Message));
                return View(editViewModel);
            }
            return RedirectToAction("Index");
        }
    }
}
