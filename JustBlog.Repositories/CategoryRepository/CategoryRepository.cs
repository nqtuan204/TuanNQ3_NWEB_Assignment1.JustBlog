using JustBlog.Core.Database;
using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Repositories.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(JustBlogContext db) : base(db)
        {

        }
    }
}