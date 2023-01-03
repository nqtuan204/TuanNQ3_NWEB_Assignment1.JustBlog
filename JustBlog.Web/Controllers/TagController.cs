using JustBlog.Services.PostService;
using JustBlog.Services.TagService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IPostService _postService;
        public TagController(ITagService tagService, IPostService postService)
        {
            _tagService = tagService;
            _postService = postService;
        }

        [Route("tag/partialview/populartags")]
        public ActionResult PopularTags()
        {
            int size = 10;
            var tags = _tagService.GetTopTags(size);
            return PartialView("_PopularTagsPartial", tags);
        }
        // GET: TagController
        public ActionResult Index()
        {
            return View();
        }

        [Route("tag/{slug}")]
        public ActionResult Details(string slug)
        {
            var posts = _postService.GetPostsByTag(slug);
            return View("~/Views/Post/Index.cshtml", posts);
        }

        // GET: TagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TagController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
