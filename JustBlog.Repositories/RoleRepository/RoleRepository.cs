using JustBlog.Core.Database;
using JustBlog.Repositories.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Repositories.RoleRepository
{
    public class RoleRepository : GenericRepository<IdentityRole<Guid>>, IRoleRepository
    {
        public RoleRepository(JustBlogContext db) : base(db)
        {
        }
    }
}
