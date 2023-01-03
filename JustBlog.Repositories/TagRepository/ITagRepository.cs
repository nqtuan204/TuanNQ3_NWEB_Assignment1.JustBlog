using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Repositories.TagRepository
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        /// <summary>
        /// Get tags which have most posts
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Tag> GetTopTags(int size);
    }
}
