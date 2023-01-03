using JustBlog.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.CommentService
{
    public interface ICommentService
    {
        IList<CommentViewModel> GetCommentsByPost(int postId);
        bool Add(NewCommentViewModel newComment);
        IList<CommentViewModel> GetPagedComments(int page, int pageSize);
        int CountAllComments();
        bool Delete(int id);
        EditCommentViewModel GetEditComment(int id);
        bool Update(EditCommentViewModel editComment);
        CommentDetailsViewModel GetDetails(int id);
    }
}
