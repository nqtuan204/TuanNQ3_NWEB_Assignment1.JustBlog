using AutoMapper;
using JustBlog.Core.Entities;
using JustBlog.ViewModels.Category;
using JustBlog.ViewModels.Comment;
using JustBlog.ViewModels.Post;
using JustBlog.ViewModels.Role;
using JustBlog.ViewModels.Tag;
using JustBlog.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace JustBlog.Web.Mapper
{
    public class MappingConfig : Profile
    {

        public MappingConfig()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<Post, PostViewModel>().ForMember(pvm => pvm.Tags, m => m.MapFrom(p => p.PostTagMaps.Select(ptm => ptm.Tag)));
            CreateMap<Post, PostAdminViewModel>();
            CreateMap<Post, PostDetailsViewModel>().ForMember(pdvm => pdvm.Tags, m => m.MapFrom(p => p.PostTagMaps.Select(ptm => ptm.Tag)));
            CreateMap<Tag, TagViewModel>();
            CreateMap<Tag, EditTagViewModel>();
            CreateMap<EditTagViewModel, Tag>();
            CreateMap<NewCategoryViewModel, Category>();
            CreateMap<EditCategoryViewModel, Category>();
            CreateMap<Category, EditCategoryViewModel>();
            CreateMap<Comment, EditCommentViewModel>();
            CreateMap<EditCommentViewModel, Comment>();
            CreateMap<EditPostViewModel, Post>();
            CreateMap<Post, EditPostViewModel>().ForMember(p => p.TagIds, epvm => epvm.MapFrom(p => p.PostTagMaps.Select(ptm => ptm.TagId)));
            CreateMap<Category, CategoryDetailsViewModel>();
            CreateMap<Comment, CommentDetailsViewModel>().ForMember(c => c.Post, cdvm => cdvm.MapFrom(c => c.Post.Title));
            CreateMap<Tag, TagDetailsViewModel>();
            CreateMap<RoleViewModel, IdentityRole<Guid>>();
            CreateMap<IdentityRole<Guid>, RoleViewModel>();
            CreateMap<UserViewModel, AppUser>();
            CreateMap<AppUser, UserViewModel>();
            CreateMap<NewUserViewModel, AppUser>();
            CreateMap<NewRoleViewModel, IdentityRole<Guid>>().ForMember(r => r.Name, nrvm => nrvm.MapFrom(r => r.Name));
            CreateMap<AppUser, UserDetailsViewModel>();
            CreateMap<UserDetailsViewModel, EditUserViewModel>().ForMember(euvm => euvm.RoleIds, m => m.MapFrom(udvm => udvm.Roles.Select(r => r.Id)));
            CreateMap<EditUserViewModel, AppUser>();
        }
    }
}
