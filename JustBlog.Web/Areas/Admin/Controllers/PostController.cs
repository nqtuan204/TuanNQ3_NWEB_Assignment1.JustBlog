using JustBlog.Core.Entities;
using JustBlog.Services.CategoryService;
using JustBlog.Services.PostService;
using JustBlog.Services.TagService;
using JustBlog.ViewModels.Others;
using JustBlog.ViewModels.Post;
using JustBlog.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Metrics;

namespace JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        public PostController(IPostService postService, ICategoryService categoryService, ITagService tagService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        [Authorize(policy: "Get")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(policy: "Get")]
        public IActionResult GetPagedPosts(int page = 1, int pageSize = 10)
        {
            var posts = _postService.GetPagedPosts(page, pageSize);
            var total = _postService.GetAllPosts().Count;
            var dataTable = new DataTableViewModel
            {
                Action = "GetPagedPosts",
                Controller = "Post",
                Total = total,
                Page = page,
                LastPage = (int)Math.Ceiling((double)total / pageSize),
                PageSize = pageSize,
                Columns = new string[] { "Id", "Title", "Published", "ViewCount", "RateCount", "TotalRate", "PostedAt", "ModifiedAt" },
                Data = posts.Select(post =>
                    new Dictionary<string, string>
                    {
                        { "Id", post.Id.ToString() },
                        { "Title", post.Title },
                        {"Published", post.Published ? "Published" : "Unpublished" },
                        {"ViewCount", post.ViewCount.ToString() },
                        {"RateCount", post.RateCount.ToString() },
                        {"TotalRate", post.TotalRate.ToString() },
                        {"PostedAt", post.PostedOn.FriendlyFormat() },
                        {"ModifiedAt", post.Modified==null?"":post.Modified.Value.FriendlyFormat() }
                    }
                ).ToList()
            };
            return PartialView("_DataTablePartial", dataTable);
        }

        [Authorize(policy: "Get")]
        public IActionResult Details(int id)
        {
            var postDetails = _postService.GetDetails(id);
            if (postDetails == null)
                return View("NotFound");
            return View(postDetails);
        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllCategories();
            ViewBag.Tags = _tagService.GetAllTags();
            return View();
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Create(NewPostViewModel newPost)
        {
            if (ModelState.IsValid && _postService.Add(newPost))
                return Redirect("/Admin/Post");

            ViewBag.Categories = _categoryService.GetAllCategories();
            ViewBag.Tags = _tagService.GetAllTags();
            return View(newPost);

        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Edit(int id)
        {
            var editPost = _postService.GetEditPost(id);
            if (editPost == null)
                return View("NotFound");

            ViewBag.Categories = _categoryService.GetAllCategories();
            ViewBag.Tags = _tagService.GetAllTags();
            return View(editPost);
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Edit(EditPostViewModel editPost)
        {
            if (ModelState.IsValid)
            {
                if (_postService.Update(editPost))
                    ViewBag.Message = "Update successfully!";
                else
                    ViewBag.Message = "Update failed!";
            }

            ViewBag.Categories = _categoryService.GetAllCategories();
            ViewBag.Tags = _tagService.GetAllTags();
            return View(editPost);
        }

        [Authorize(policy: "Delete")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (_postService.Delete(id))
                return StatusCode(200);
            return View("NotFound");
        }

        [Authorize(policy: "Publish/Unpublish")]
        public ActionResult ChangePublish(int id)
        {
            if (_postService.ChangePublish(id))
                return StatusCode(200);
            return View("NotFound");
        }
    }
}