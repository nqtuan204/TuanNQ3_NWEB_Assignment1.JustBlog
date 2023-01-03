using JustBlog.Core.Entities;
using JustBlog.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.TagService
{
    public interface ITagService
    {
        IList<TagViewModel> GetTopTags(int size);
        IList<TagViewModel> GetPagedTags(int page, int pageSize);
        int CountAllTags();
        bool Delete(int id);
        bool Add(NewTagViewModel newTag);
        IList<TagViewModel> GetAllTags();
        EditTagViewModel GetEditTag(int id);
        bool Update(EditTagViewModel editTag);
        TagDetailsViewModel GetDetails(int id);
    }
}
