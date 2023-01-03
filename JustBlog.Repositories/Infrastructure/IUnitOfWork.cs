using JustBlog.Core.Entities;
using JustBlog.Repositories.CategoryRepository;
using JustBlog.Repositories.CommentRepository;
using JustBlog.Repositories.PostRepository;
using JustBlog.Repositories.RoleRepository;
using JustBlog.Repositories.TagRepository;
using JustBlog.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Repositories.Infrastructure
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IPostRepository PostRepository { get; }
        public ITagRepository TagRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IUserRepository UserRepository { get; }
        
        //void CreateTransaction();
        //void Commit();
        //void Rollback();
        void Save();
    }
}
