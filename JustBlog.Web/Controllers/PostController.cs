using JustBlog.Services.PostService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: PostController
        public ActionResult Index()
        {
            var posts = _postService.GetAllPostsWithCategoryAndTags();
            return View(posts);
        }

        public ActionResult AboutCard()
        {
            return PartialView("_AboutCardPartial");
        }

        [ActionName("Latest")]
        public ActionResult LatestPost()
        {
            int size = 5;
            var posts = _postService.GetLatestPosts(size);
            return View(posts);
        }

        public ActionResult LatestPosts()
        {
            int size = 5;
            var posts = _postService.GetLatestPosts(size);
            return PartialView("_ListPostsPartial", posts);
        }
        public ActionResult MostViewedPosts()
        {
            int size = 5;
            var posts = _postService.GetMostViewedPosts(size);
            return PartialView("_ListPostsPartial", posts);
        }

        [Route("post/{year}/{month}/{slug}")]
        public ActionResult Details(int year, int month, string slug)
        {
            var post = _postService.GetDetails(year, month, slug);
            if (post == null)
                return View("NotFound");
            return View(post);
        }
    }
}
