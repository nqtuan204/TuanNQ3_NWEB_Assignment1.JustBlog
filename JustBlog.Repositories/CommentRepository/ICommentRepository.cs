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
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        /// <summary>
        /// Get comments of post with postId
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        IList<Comment> GetCommentsForPost(int postId);
        /// <summary>
        /// Get comments of a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        IList<Comment> GetCommentsForPost(Post post);
        void Add(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);
    }
}
