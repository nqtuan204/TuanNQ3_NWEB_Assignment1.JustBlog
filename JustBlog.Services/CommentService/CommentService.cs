using AutoMapper;
using JustBlog.Core.Database;
using JustBlog.Core.Entities;
using JustBlog.Repositories.CommentRepository;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels.Comment;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CommentService> _logger;
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CommentService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IList<CommentViewModel> GetCommentsByPost(int postId)
        {
            var comments = _unitOfWork.CommentRepository.GetCommentsForPost(postId);
            return comments.OrderByDescending(c => c.CommentTime).Select(c => _mapper.Map<CommentViewModel>(c)).ToList();
        }
        public bool Add(NewCommentViewModel newComment)
        {
            try
            {
                _unitOfWork.CommentRepository.Add(newComment.PostId, newComment.Name, newComment.Email, newComment.CommentHeader, newComment.CommentText);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public IList<CommentViewModel> GetPagedComments(int page, int pageSize)
        {
            return _unitOfWork.CommentRepository.GetPagedItems(page, pageSize).Select(c => _mapper.Map<CommentViewModel>(c)).ToList();
        }

        public int CountAllComments()
        {
            return _unitOfWork.CommentRepository.CountAll();
        }

        public bool Delete(int id)
        {
            try
            {
                _unitOfWork.CommentRepository.DeleteById(id);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public EditCommentViewModel GetEditComment(int id)
        {
            return _mapper.Map<EditCommentViewModel>(_unitOfWork.CommentRepository.Find(id));
        }

        public bool Update(EditCommentViewModel editComment)
        {

            try
            {
                var comment = _mapper.Map<Comment>(editComment);
                _unitOfWork.CommentRepository.Update(comment);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public CommentDetailsViewModel GetDetails(int id)
        {
            return _mapper.Map<CommentDetailsViewModel>(_unitOfWork.CommentRepository.Find(id));
        }
    }
}
