using JustBlog.Core.Database;
using JustBlog.Repositories.Infrastructure;
using JustBlog.Services.CategoryService;
using JustBlog.Services.CommentService;
using JustBlog.Services.PostService;
using JustBlog.Services.TagService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JustBlog.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using NLog.Web;
using NLog;
using Microsoft.Extensions.Logging;
using JustBlog.Services.RoleService;
using JustBlog.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace JustBlog.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("init main");

            try
            {
                var builder = WebApplication.CreateBuilder(args);


                builder.Services.AddControllersWithViews();

                builder.Services.AddDbContext<JustBlogContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

                builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<JustBlogContext>()
                    .AddDefaultTokenProviders();

                builder.Services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequiredUniqueChars = 1;

                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = true;

                    options.SignIn.RequireConfirmedEmail = true;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                });

                builder.Services.ConfigureApplicationCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.LoginPath = $"/admin/auth/login/";
                    options.LogoutPath = $"/admin/auth/logout/";
                    options.AccessDeniedPath = $"/admin/auth/AccessDenied";
                });

                builder.Services.AddAuthentication();

                builder.Services.AddAuthorization(config =>
                {
                    config.AddPolicy("Get", policy => policy.RequireRole(new string[] { "User", "Contributor", "Blog Owner" }));
                    config.AddPolicy("Create Or Edit", policy => policy.RequireRole(new string[] { "Contributor", "Blog Owner" }));
                    config.AddPolicy("Publish/Unpublish", policy => policy.RequireRole("Blog Owner"));
                    config.AddPolicy("Delete", policy => policy.RequireRole("Blog Owner"));
                });


                builder.Services.AddAutoMapper(config => config.AddProfile<Mapper.MappingConfig>());

                builder.Services.AddScoped<IPostService, PostService>();

                builder.Services.AddScoped<ITagService, TagService>();

                builder.Services.AddScoped<ICategoryService, CategoryService>();

                builder.Services.AddScoped<ICommentService, CommentService>();

                builder.Services.AddScoped<IRoleService, RoleService>();

                builder.Services.AddScoped<IUserService, UserService>();

                builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

                builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                builder.Host.UseNLog();

                var app = builder.Build();


                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");

                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthentication();

                app.UseAuthorization();

                app.UseEndpoints(endpoinst =>
                {
                    endpoinst.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                    endpoinst.MapControllerRoute(
                        name: "areas",
                        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                });

                app.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
    }
}