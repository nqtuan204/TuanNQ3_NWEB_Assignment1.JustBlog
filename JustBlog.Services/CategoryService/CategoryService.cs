using AutoMapper;
using JustBlog.Core.Database;
using JustBlog.Core.Entities;
using JustBlog.Repositories.CategoryRepository;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels.Category;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IList<CategoryViewModel> GetAllCategories()
        {
            return _unitOfWork.CategoryRepository.GetAll().Select(c => _mapper.Map<CategoryViewModel>(c)).ToList();
        }

        public IList<CategoryViewModel> GetPagedCategories(int page, int pageSize)
        {
            return _unitOfWork.CategoryRepository.GetPagedItems(page, pageSize).Select(c => _mapper.Map<CategoryViewModel>(c)).ToList();
        }
        public int CountAllCategories()
        {
            return _unitOfWork.CategoryRepository.CountAll();
        }

        public bool Delete(int id)
        {
            try
            {
                _unitOfWork.CategoryRepository.DeleteById(id);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public bool Add(NewCategoryViewModel newCategory)
        {
            var category = _mapper.Map<Category>(newCategory);
            try
            {
                _unitOfWork.CategoryRepository.Insert(category);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public EditCategoryViewModel GetEditCategoryById(int id)
        {
            return _mapper.Map<EditCategoryViewModel>(_unitOfWork.CategoryRepository.Find(id));
        }

        public bool Update(EditCategoryViewModel editCategory)
        {
            var category = _mapper.Map<Category>(editCategory);
            try
            {
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public CategoryDetailsViewModel GetDetails(int id)
        {
            return _mapper.Map<CategoryDetailsViewModel>(_unitOfWork.CategoryRepository.Find(id));
        }
    }
}
