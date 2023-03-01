using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class DesignationBusiness : IGenericBusiness<DesignationDto>
    {
        private readonly IGenericRepository<Designation> _designationRepository;
        private readonly ILogger<DesignationBusiness> _logger;
        private readonly IMapper _modelMapper;

        public DesignationBusiness(IGenericRepository<Designation> designationRepository
            , ILogger<DesignationBusiness> logger
            , IMapper modelMapper)
        {
            _designationRepository = designationRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<DesignationDto> Create(DesignationDto item)
        {
            try
            {
                var designation = _modelMapper.Map<Designation>(item);
                var createdRecord = await _designationRepository.Create(designation);
                return _modelMapper.Map<DesignationDto>(createdRecord);
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
                await _designationRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DesignationDto> Edit(DesignationDto item)
        {
            try
            {
                var designation = _modelMapper.Map<Designation>(item);
                var updatedRecord = await _designationRepository.Edit(designation);
                return _modelMapper.Map<DesignationDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DesignationDto>> GetAll()
        {
            try
            {
                var designations = await _designationRepository.GetAll();
                return _modelMapper.Map<List<DesignationDto>>(designations);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DesignationDto> GetById(long id)
        {
            try
            {
                var designation = await _designationRepository.GetById(id);
                return _modelMapper.Map<DesignationDto>(designation);
            }
            catch
            {
                throw;
            }
        }

        public Task<DesignationDto> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
