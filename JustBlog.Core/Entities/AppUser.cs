using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JustBlog.Core.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public int Age { get; set; }
        public string AboutMe { get; set; }
    }
}
