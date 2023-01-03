using JustBlog.Core.Database;
using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Repositories.PostRepository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext db) : base(db) { }

        public IList<Post> GetLatestPost(int size)
        {
            return _db.Posts.OrderByDescending(p => p.PostedOn).Take(size).ToList();
        }
        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _db.Posts.Where(p => p.PostedOn.Month == monthYear.Month).ToList();
        }
        public IList<Post> GetPostsByCategory(string category)
        {
            return _db.Posts.Where(p => p.Category.UrlSlug == category).Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).ToList();
        }
        public IList<Post> GetPostsByTag(string tag)
        {
            return _db.Tags.Where(t => t.UrlSlug == tag).SelectMany(t => t.PostTagMaps.Select(ptm => ptm.Post)).Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).ToList();
        }

        public IList<Post> GetMostViewedPosts(int size)
        {
            return _db.Posts.OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }
        public IList<Post> GetHighestPosts(int size)
        {
            return _db.Posts.AsEnumerable().OrderByDescending(p => p.Rate).Take(size).ToList();
        }
        public IList<Post> GetAllPostsWithCategoryAndTags()
        {
            return _db.Posts.Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).Include(p => p.Comments).ToList();
        }

        public void AddTags(int postId, IList<int> tagIds)
        {
            var postTagMaps = tagIds.Select(tagId => new PostTagMap
            {
                PostId = postId,
                TagId = tagId
            });
            _db.PostTagMaps.AddRange(postTagMaps);
        }

        public void DeleteTags(int postId)
        {
            _db.PostTagMaps.RemoveRange(_db.PostTagMaps.Where(ptm => ptm.PostId == postId));
        }
        public Post GetPostWithTags(int id)
        {
            return _db.Posts.Include(p => p.PostTagMaps).First(p => p.Id == id);
        }
        public Post GetDetails(int year, int month, string urlSlug)
        {
            return _db.Posts.Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).Include(p => p.Comments).First(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug == urlSlug);
        }

        public void ChangePublish(int id)
        {
            var post = _db.Posts.Find(id);
            post.Published = !post.Published;
            _db.Update(post);
        }
    }
}
