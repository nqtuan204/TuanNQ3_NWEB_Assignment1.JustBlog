using JustBlog.Core.Database;
using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Repositories.CommentRepository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(JustBlogContext db) : base(db) { }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            var c = _db.Comments.ToList();
            return _db.Comments.Where(c => c.PostId == postId).ToList();
        }
        public IList<Comment> GetCommentsForPost(Post post)
        {
            return _db.Comments.Where(c => c.PostId == post.Id).ToList();
        }

        public void Add(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment()
            {
                PostId = postId,
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommentTime = DateTime.Now
            };
            _db.Comments.Add(comment);
        }
    }
}
