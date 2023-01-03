using JustBlog.Services.CategoryService;
using JustBlog.Services.TagService;
using JustBlog.ViewModels.Others;
using JustBlog.ViewModels.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize(policy: "Get")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(policy: "Get")]
        public IActionResult GetPagedCategories(int page = 1, int pageSize = 10)
        {
            var posts = _categoryService.GetPagedCategories(page, pageSize);
            var total = _categoryService.CountAllCategories();
            var dataTable = new DataTableViewModel
            {
                Action = "GetPagedCategories",
                Controller = "Category",
                Total = total,
                Page = page,
                LastPage = (int)Math.Ceiling((double)total / pageSize),
                PageSize = pageSize,
                Columns = new string[] { "Id", "Name", "Slug", "Description" },
                Data = posts.Select(category =>
                    new Dictionary<string, string>
                    {
                        { "Id", category.Id.ToString() },
                        { "Name", category.Name },
                        {"Slug", category.UrlSlug },
                        { "Description", category.Description }
                    }
                ).ToList()
            };
            return PartialView("_DataTablePartial", dataTable);
        }

        [Authorize(policy: "Get")]
        public IActionResult Details(int id)
        {
            var category = _categoryService.GetDetails(id);
            if (category == null)
                return View("NotFound");
            return View(category);
        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Create(NewCategoryViewModel newCategory)
        {
            if (ModelState.IsValid && _categoryService.Add(newCategory))
                return Redirect("/Admin/Category");
            return View(newCategory);
        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetEditCategoryById(id);
            if (category == null)
                return View("NotFound");
            return View(category);
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Edit(EditCategoryViewModel editCategory)
        {
            if (ModelState.IsValid)
            {
                if (_categoryService.Update(editCategory))
                    ViewBag.Message = "Update successfully!";
                else
                    ViewBag.Message = "Update failed!";
            }
            return View(editCategory);

        }

        [Authorize(policy: "Delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_categoryService.Delete(id))
                return StatusCode(200);
            return View("NotFound");
        }
    }
}
