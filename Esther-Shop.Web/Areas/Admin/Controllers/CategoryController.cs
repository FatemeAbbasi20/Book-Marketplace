using Esther_Shop.CoreLayer.Dtos.Categoris;
using Esther_Shop.CoreLayer.Services.Category;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.Web.Areas.Admin.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Esther_Shop.Web.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategory);
        }
        [Route("/Admin/Category/Create/{parentId?}")]
        public IActionResult Create(int? parentId)
        {
            return View();
        }
        [HttpPost]
        [Route("/Admin/Category/Create/{parentId?}")]
        public IActionResult Create(int? parentId, CreateCategoryViewModel createViewModel)
        {
            createViewModel.ParentId = parentId;
            var result = _categoryService.CreateCategory(createViewModel.MapToDto());
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
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            var model = new EditCategoryArticleViewModel()
            {
                Slug = category.Slug, MetaDescription = category.MetaDescription,
               Title = category.Title,
               Id=category.Id
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCategoryArticleViewModel EditViewModel)
        {
            var result = _categoryService.EditCategory(new EditCategoryDto()
            {
                Slug = EditViewModel.Slug,
                MetaDescription = EditViewModel.MetaDescription,
                Title = EditViewModel.Title,
                Id= EditViewModel.Id
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(EditViewModel.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");

        }
        public IActionResult GetChildCategories(int parentId)
        {
           var category= _categoryService.GetChildCategories(parentId);
            return new JsonResult(category);
        }
    }
    }
