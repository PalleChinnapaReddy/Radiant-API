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
    public class OtStatusBusiness : IGenericBusiness<OtStatusDto>
    {
        private readonly IGenericRepository<OtStatus> _otStatusRepository;
        private readonly ILogger<OtStatusBusiness> _logger;
        private readonly IMapper _modelMapper;

        public OtStatusBusiness(IGenericRepository<OtStatus> otStatusRepository
            , ILogger<OtStatusBusiness> logger
            , IMapper modelMapper)
        {
            _otStatusRepository = otStatusRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<OtStatusDto> Create(OtStatusDto item)
        {
            try
            {
                var absenceReason = _modelMapper.Map<OtStatus>(item);
                var createdRecord = await _otStatusRepository.Create(absenceReason);
                return _modelMapper.Map<OtStatusDto>(createdRecord);
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
                await _otStatusRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<OtStatusDto> Edit( OtStatusDto item)
        {
            try
            {
                var absenceReason = _modelMapper.Map<OtStatus>(item);
                var updatedRecord = await _otStatusRepository.Edit( absenceReason);
                return _modelMapper.Map<OtStatusDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<OtStatusDto>> GetAll()
        {
            try
            {
                var otStatuses = await _otStatusRepository.GetAll();
                return _modelMapper.Map<List<OtStatusDto>>(otStatuses);
            }
            catch
            {
                throw;
            }
        }

        public async Task<OtStatusDto> GetById(long id)
        {
            try
            {
                var otStatus = await _otStatusRepository.GetById(id);
                return _modelMapper.Map<OtStatusDto>(otStatus);
            }
            catch
            {
                throw;
            }
        }

        public Task<OtStatusDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
