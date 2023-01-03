using JustBlog.Services.CommentService;
using JustBlog.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CommentsByPosts(int id)
        {
            var comments = _commentService.GetCommentsByPost(id);
            return PartialView("_CommentListPartial", comments);
        }

        public IActionResult AddComment([FromBody] NewCommentViewModel newComment)
        {
            _commentService.Add(newComment);
            return StatusCode(200);
        }
    }
}
