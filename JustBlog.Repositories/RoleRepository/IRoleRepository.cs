using JustBlog.Repositories.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Repositories.RoleRepository
{
    public interface IRoleRepository : IGenericRepository<IdentityRole<Guid>>
    {

    }
}
