using AutoMapper;
using JustBlog.Core.Database;
using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;
using JustBlog.Repositories.PostRepository;
using JustBlog.ViewModels.Post;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PostService> _logger;
        public PostService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IList<PostViewModel> GetAllPosts()
        {
            return _unitOfWork.PostRepository.GetAll().Select(p => _mapper.Map<PostViewModel>(p)).ToList();
        }

        public IList<PostViewModel> GetLatestPosts(int size)
        {
            return _unitOfWork.PostRepository.GetLatestPost(size).Select(p => _mapper.Map<PostViewModel>(p)).ToList();
        }

        public IList<PostViewModel> GetMostViewedPosts(int size)
        {
            return _unitOfWork.PostRepository.GetMostViewedPosts(size).Select(p => _mapper.Map<PostViewModel>(p)).ToList();
        }

        public PostDetailsViewModel GetDetails(int id)
        {
            try
            {
                return _mapper.Map<PostDetailsViewModel>(_unitOfWork.PostRepository.GetAllPostsWithCategoryAndTags().First(p => p.Id == id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public PostDetailsViewModel GetDetails(int year, int month, string urlSlug)
        {
            try
            {
                var post = _unitOfWork.PostRepository.GetDetails(year, month, urlSlug);
                var postDetails = _mapper.Map<PostDetailsViewModel>(post);
                return postDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public IList<PostViewModel> GetPostsByCategory(string urlSlug)
        {
            return _unitOfWork.PostRepository.GetPostsByCategory(urlSlug).Select(p => _mapper.Map<PostViewModel>(p)).ToList();
        }

        public IList<PostViewModel> GetPostsByTag(string urlSlug)
        {
            return _unitOfWork.PostRepository.GetPostsByTag(urlSlug).Select(p => _mapper.Map<PostViewModel>(p)).ToList();
        }

        public IList<PostAdminViewModel> GetPagedPosts(int page, int pageSize)
        {
            return _unitOfWork.PostRepository.GetPagedItems(page, pageSize).Select(p => _mapper.Map<PostAdminViewModel>(p)).ToList();
        }
        public IList<PostViewModel> GetAllPostsWithCategoryAndTags()
        {
            return _unitOfWork.PostRepository.GetAllPostsWithCategoryAndTags().Select(p => _mapper.Map<PostViewModel>(p)).ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                _unitOfWork.PostRepository.DeleteById(id);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public bool Add(NewPostViewModel newPost)
        {
            var post = new Post
            {
                CategoryId = newPost.CategoryId,
                PostContent = newPost.PostContent,
                PostedOn = DateTime.Now,
                ShortDescription = newPost.ShortDescription,
                UrlSlug = newPost.UrlSlug,
                Published = newPost.Published,
                Title = newPost.Title
            };
            try
            {
                _unitOfWork.PostRepository.Insert(post);
                _unitOfWork.Save();
                var postId = post.Id;

                _unitOfWork.PostRepository.AddTags(postId, newPost.TagIds);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public EditPostViewModel GetEditPost(int id)
        {
            return _mapper.Map<EditPostViewModel>(_unitOfWork.PostRepository.GetPostWithTags(id));
        }

        public bool Update(EditPostViewModel editPost)
        {
            try
            {
                var post = _mapper.Map<Post>(editPost);
                post.Modified = DateTime.Now;
                _unitOfWork.PostRepository.Update(post);
                _unitOfWork.PostRepository.DeleteTags(editPost.Id);
                _unitOfWork.PostRepository.AddTags(editPost.Id, editPost.TagIds);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public bool ChangePublish(int id)
        {
            try
            {
                _unitOfWork.PostRepository.ChangePublish(id);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
