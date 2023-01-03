using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using JustBlog.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace JustBlog.Core.Database
{
    public class JustBlogContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public JustBlogContext() { }
        public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            modelBuilder.Entity<Post>(post =>
            {
                post.ToTable("Posts");
                post.HasOne(p => p.Category).WithMany(c => c.Posts).HasForeignKey(p => p.CategoryId);
            });

            modelBuilder.Entity<Comment>(comment =>
            {
                comment.ToTable("Comments");
                comment.HasOne(c => c.Post).WithMany(p => p.Comments).HasForeignKey(c => c.PostId);
            });

            modelBuilder.Entity<PostTagMap>(postTagMap =>
            {
                postTagMap.ToTable("PostTagMaps");
                postTagMap.HasKey(ptm => new { ptm.TagId, ptm.PostId });

                postTagMap.HasOne(ptm => ptm.Tag).WithMany(t => t.PostTagMaps).HasForeignKey(ptm => ptm.TagId);
                postTagMap.HasOne(ptm => ptm.Post).WithMany(p => p.PostTagMaps).HasForeignKey(ptm => ptm.PostId);
            });

            modelBuilder.Seed();
        }
    }
}