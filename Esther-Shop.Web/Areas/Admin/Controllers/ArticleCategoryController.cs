using Esther_Shop.CoreLayer.Dtos.ArticleCategories;
using Esther_Shop.CoreLayer.Dtos.Categoris;
using Esther_Shop.CoreLayer.Services.Article;
using Esther_Shop.CoreLayer.Services.ArticleCategory;
using Esther_Shop.CoreLayer.Services.Category;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.Web.Areas.Admin.Models.Category;
using Esther_Shop.Web.Areas.Admin.Models.CategoryArticle;
using Microsoft.AspNetCore.Mvc;

namespace Esther_Shop.Web.Areas.Admin.Controllers
{
    public class ArticleCategoryController : AdminBaseController
    {
        private readonly IArticleCategoryService _articlCategoryService;

        public ArticleCategoryController(IArticleCategoryService categoryService)
        {
            _articlCategoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_articlCategoryService.GetAllArticleCategory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( CreateCategoryArticleViewModel createViewModel)
        {
            var result = _articlCategoryService.CreateArticleCategory(createViewModel.MapToDto());
            //if (result.Status != OperationResultStatus.Success)
            //{
            //    ModelState.AddModelError(nameof(createViewModel.Slug), result.Message);
            //    return View();
            //}
            //return RedirectToAction("Index");
            return RedirectAndShowAlert(result, RedirectToAction("Index"));
        }

        public IActionResult Edit(int id)
        {
            var category = _articlCategoryService.GetArticleCategoryById(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            var model = new EditCategoryArticleViewModel()
            {
                Slug = category.Slug,
                Title = category.Title,
                Id=category.Id
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCategoryArticleViewModel EditViewModel)
        {
            var result = _articlCategoryService.EditArticleCategory(new EditArticleCategoryDto()
            {
                Slug = EditViewModel.Slug,
                Title = EditViewModel.Title,
                Id=EditViewModel.Id
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(EditViewModel.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");

        }
       
    }
}
