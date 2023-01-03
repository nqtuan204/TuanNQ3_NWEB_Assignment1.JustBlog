using JustBlog.Core.Database;
using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels.Tag;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Repositories.TagRepository
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext db) : base(db) { }

        public IList<Tag> GetTopTags(int size)
        {
            return _db.Tags.OrderByDescending(t => t.PostTagMaps.Count).Take(size).ToList();
        }
    }
}
