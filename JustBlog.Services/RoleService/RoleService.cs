using AutoMapper;
using JustBlog.Core.Database;
using JustBlog.Repositories.Infrastructure;
using JustBlog.Repositories.RoleRepository;
using JustBlog.ViewModels.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<RoleService> _logger;
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<RoleService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public bool Add(NewRoleViewModel role)
        {
            try
            {
                var newRole = _mapper.Map<IdentityRole<Guid>>(role);
                newRole.Id = Guid.NewGuid();
                newRole.NormalizedName = role.Name.ToUpper();
                _unitOfWork.RoleRepository.Insert(newRole);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public bool Update(RoleViewModel role)
        {
            try
            {
                var newRole = _mapper.Map<IdentityRole<Guid>>(role);
                _unitOfWork.RoleRepository.Update(newRole);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var deleteRole = _unitOfWork.RoleRepository.FindByCondition(r => r.Id == id);
                _unitOfWork.RoleRepository.Delete(deleteRole);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public IList<RoleViewModel> GetAll()
        {
            return _unitOfWork.RoleRepository.GetAll().Select(r => _mapper.Map<RoleViewModel>(r)).ToList();
        }

        public IList<RoleViewModel> GetPagedRoles(int page, int pageSize)
        {
            var roles = _unitOfWork.RoleRepository.GetPagedItems(page, pageSize);

            return roles.Select(r => _mapper.Map<RoleViewModel>(r)).ToList();
        }

        public RoleViewModel GetDetails(Guid id)
        {
            try
            {
                var role = _unitOfWork.RoleRepository.FindByCondition(r => r.Id == id);
                return _mapper.Map<RoleViewModel>(role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public int CountAll()
        {
            return _unitOfWork.RoleRepository.CountAll();
        }
    }
}
