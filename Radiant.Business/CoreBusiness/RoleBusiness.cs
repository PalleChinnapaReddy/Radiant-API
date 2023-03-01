using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class RoleBusiness : IGenericBusiness<RoleDto>
    {
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly ILogger<RoleBusiness> _logger;
        private readonly IMapper _modelMapper;

        public RoleBusiness(IGenericRepository<Role> roleRepository
            , ILogger<RoleBusiness> logger
            , IMapper modelMapper)
        {
            _roleRepository = roleRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<RoleDto> Create(RoleDto item)
        {
            try
            {
                var role = _modelMapper.Map<Role>(item);
                var createdRecord = await _roleRepository.Create(role);
                return _modelMapper.Map<RoleDto>(createdRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                await _roleRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<RoleDto> Edit(RoleDto item)
        {
            try
            {
                var role = _modelMapper.Map<Role>(item);
                var updatedRecord = await _roleRepository.Edit(role);
                return _modelMapper.Map<RoleDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RoleDto>> GetAll()
        {
            try
            {
                var roles = await _roleRepository.GetAll();
                return _modelMapper.Map<List<RoleDto>>(roles);
            }
            catch
            {
                throw;
            }
        }

        public async Task<RoleDto> GetById(long id)
        {
            try
            {
                var role = await _roleRepository.GetById(id);
                return _modelMapper.Map<RoleDto>(role);
            }
            catch
            {
                throw;
            }
        }

        public async Task<RoleDto> GetByName(string name)
        {
            try
            {
                var role = await _roleRepository.GetByName(name);
                return _modelMapper.Map<RoleDto>(role);
            }
            catch
            {
                throw;
            }
        }
    }
}


