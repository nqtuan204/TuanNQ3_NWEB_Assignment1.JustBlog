using JustBlog.Core.Entities;
using JustBlog.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.PostService
{
    public interface IPostService
    {
        IList<PostViewModel> GetAllPosts();
        IList<PostViewModel> GetLatestPosts(int size);
        IList<PostViewModel> GetMostViewedPosts(int size);
        PostDetailsViewModel GetDetails(int id);

        PostDetailsViewModel GetDetails(int year, int month, string urlSlug);
        IList<PostViewModel> GetPostsByCategory(string urlSlug);
        IList<PostViewModel> GetPostsByTag(string urlSlug);
        IList<PostAdminViewModel> GetPagedPosts(int page, int pageSize);
        IList<PostViewModel> GetAllPostsWithCategoryAndTags();
        bool Delete(int id);
        bool Add(NewPostViewModel newPost);
        EditPostViewModel GetEditPost(int id);
        bool Update(EditPostViewModel editPost);
        bool ChangePublish(int id);
    }
}
