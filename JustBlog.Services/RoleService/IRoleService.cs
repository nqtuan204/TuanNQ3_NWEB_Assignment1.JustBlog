using JustBlog.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.RoleService
{
    public interface IRoleService
    {
        bool Add(NewRoleViewModel role);
        bool Update(RoleViewModel role);
        bool Delete(Guid id);
        IList<RoleViewModel> GetAll();
        IList<RoleViewModel> GetPagedRoles(int page, int pageSize);
        RoleViewModel GetDetails(Guid id);
        int CountAll();
    }
}
