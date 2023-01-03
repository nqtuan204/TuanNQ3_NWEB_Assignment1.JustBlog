using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Repositories.PostRepository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        /// <summary>
        /// Get list of latest posts
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Post> GetLatestPost(int size);

        /// <summary>
        /// Get list of posts by category name
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        IList<Post> GetPostsByCategory(string category);

        /// <summary>
        /// Get list of posts by tag name
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        IList<Post> GetPostsByTag(string tag);

        /// <summary>
        /// Get top most viewed posts with a parameter: size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Post> GetMostViewedPosts(int size);

        /// <summary>
        /// Get top highest rate posts with a parameter: size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Post> GetHighestPosts(int size);
        IList<Post> GetAllPostsWithCategoryAndTags();
        void AddTags(int postId, IList<int> tagIds);
        void DeleteTags(int postId);
        Post GetPostWithTags(int id);
        Post GetDetails(int year, int month, string urlSlug);
        void ChangePublish(int id);
    }
}
