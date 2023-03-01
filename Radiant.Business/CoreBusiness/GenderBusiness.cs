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
    public class GenderBusiness : IGenericBusiness<GenderDto>
    {
        private readonly IGenericRepository<Gender> _genderRepository;
        private readonly ILogger<GenderBusiness> _logger;
        private readonly IMapper _modelMapper;

        public GenderBusiness(IGenericRepository<Gender> genderRepository
            , ILogger<GenderBusiness> logger
            , IMapper modelMapper)
        {
            _genderRepository = genderRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<GenderDto> Create(GenderDto item)
        {
            try
            {
                var gender = _modelMapper.Map<Gender>(item);
                var createdRecord = await _genderRepository.Create(gender);
                return _modelMapper.Map<GenderDto>(createdRecord);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                await _genderRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenderDto> Edit(GenderDto item)
        {
            try
            {
                var gender = _modelMapper.Map<Gender>(item);
                var updatedRecord = await _genderRepository.Edit( gender);
                return _modelMapper.Map<GenderDto>(updatedRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<GenderDto>> GetAll()
        {
            try
            {
                var genders = await _genderRepository.GetAll();
                return _modelMapper.Map<List<GenderDto>>(genders);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenderDto> GetById(long id)
        {
            try
            {
                var gender = await _genderRepository.GetById(id);
                return _modelMapper.Map<GenderDto>(gender);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<GenderDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
