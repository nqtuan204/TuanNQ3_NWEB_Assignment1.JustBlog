using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        IList<IdentityRole<Guid>> GetRoles(Guid id);
        void AddRoles(Guid id, IList<Guid> roleIds);
        void DeleteRoles(Guid id);
    }
}
