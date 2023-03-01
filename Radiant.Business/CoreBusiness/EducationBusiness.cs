using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class EducationBusiness : IGenericBusiness<EducationDto>
    {
        private readonly IGenericRepository<Education> _educationRepository;
        private readonly ILogger<EducationBusiness> _logger;
        private readonly IMapper _modelMapper;

        public EducationBusiness(IGenericRepository<Education> educationRepository
            , ILogger<EducationBusiness> logger
            , IMapper modelMapper)
        {
            _educationRepository = educationRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<EducationDto> Create(EducationDto item)
        {
            try
            {
                var education = _modelMapper.Map<Education>(item);
                var createdRecord = await _educationRepository.Create(education);
                return _modelMapper.Map<EducationDto>(createdRecord);
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
                await _educationRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EducationDto> Edit(EducationDto item)
        {
            try
            {
                var education = _modelMapper.Map<Education>(item);
                var updatedRecord = await _educationRepository.Edit(education);
                return _modelMapper.Map<EducationDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EducationDto>> GetAll()
        {
            try
            {
                var educations = await _educationRepository.GetAll();
                return _modelMapper.Map<List<EducationDto>>(educations);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EducationDto> GetById(long id)
        {
            try
            {
                var education = await _educationRepository.GetById(id);
                return _modelMapper.Map<EducationDto>(education);
            }
            catch
            {
                throw;
            }
        }

        public Task<EducationDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
