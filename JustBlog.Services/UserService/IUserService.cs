using JustBlog.ViewModels.Role;
using JustBlog.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.UserService
{
    public interface IUserService
    {
        bool Add(NewUserViewModel user);
        bool Update(EditUserViewModel user);
        bool Delete(Guid id);
        IList<UserViewModel> GetAll();
        IList<UserViewModel> GetPagedUsers(int page, int pageSize);
        UserDetailsViewModel GetDetails(Guid id);
        EditUserViewModel GetEditUser(Guid id);
        int CountAll();
    }
}
