using AutoMapper;
using JustBlog.Core.Database;
using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;
using JustBlog.Repositories.TagRepository;
using JustBlog.ViewModels.Tag;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.TagService
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<TagService> _logger;
        public TagService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TagService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public IList<TagViewModel> GetTopTags(int size)
        {
            return _unitOfWork.TagRepository.GetTopTags(size).Select(t => _mapper.Map<TagViewModel>(t)).ToList();
        }
        public IList<TagViewModel> GetPagedTags(int page, int pageSize)
        {
            return _unitOfWork.TagRepository.GetPagedItems(page, pageSize).Select(t => _mapper.Map<TagViewModel>(t)).ToList();
        }
        public IList<TagViewModel> GetAllTags()
        {
            return _unitOfWork.TagRepository.GetAll().Select(t => _mapper.Map<TagViewModel>(t)).ToList();
        }
        public int CountAllTags()
        {
            return _unitOfWork.TagRepository.CountAll();
        }

        public bool Delete(int id)
        {
            try
            {
                _unitOfWork.TagRepository.DeleteById(id);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public bool Add(NewTagViewModel newTag)
        {
            var tag = new Tag
            {
                Name = newTag.Name,
                Description = newTag.Description,
                UrlSlug = newTag.UrlSlug
            };
            try
            {
                _unitOfWork.TagRepository.Insert(tag);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public EditTagViewModel GetEditTag(int id)
        {
            return _mapper.Map<EditTagViewModel>(_unitOfWork.TagRepository.Find(id));
        }

        public bool Update(EditTagViewModel editTag)
        {
            var tag = _mapper.Map<Tag>(editTag);
            try
            {
                _unitOfWork.TagRepository.Update(tag);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public TagDetailsViewModel GetDetails(int id)
        {
            return _mapper.Map<TagDetailsViewModel>(_unitOfWork.TagRepository.Find(id));
        }
    }
}
