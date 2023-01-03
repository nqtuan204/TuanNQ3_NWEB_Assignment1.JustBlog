using JustBlog.Core.Database;
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
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private readonly JustBlogContext _db;
        private ICategoryRepository categoryRepository;
        private ICommentRepository commentRepository;
        private IPostRepository postRepository;
        private ITagRepository tagRepository;
        private IRoleRepository roleRepository;
        private IUserRepository userRepository;

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository.CategoryRepository(_db);
                return categoryRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository.CommentRepository(_db);
                return commentRepository;
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                if (postRepository == null)
                    postRepository = new PostRepository.PostRepository(_db);
                return postRepository;
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository.TagRepository(_db);
                return tagRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository.RoleRepository(_db);
                return roleRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository.UserRepository(_db);
                return userRepository;
            }
        }

        public UnitOfWork(JustBlogContext db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
