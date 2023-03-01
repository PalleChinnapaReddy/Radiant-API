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
    public class ContractorTrackerBusiness : IGenericBusiness<ContractorTrackerDto>
    {
        private readonly IGenericRepository<ContractorTracker> _contractorTrackerRepository;
        private readonly ILogger<ContractorTrackerBusiness> _logger;
        private readonly IMapper _modelMapper;

        public ContractorTrackerBusiness(IGenericRepository<ContractorTracker> contractorTrackerRepository
            , ILogger<ContractorTrackerBusiness> logger
            , IMapper modelMapper)
        {
            _contractorTrackerRepository = contractorTrackerRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<ContractorTrackerDto> Create(ContractorTrackerDto item)
        {
            try
            {
                var contractorTracker = _modelMapper.Map<ContractorTracker>(item);
                var createdRecord = await _contractorTrackerRepository.Create(contractorTracker);
                return _modelMapper.Map<ContractorTrackerDto>(createdRecord);
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
                await _contractorTrackerRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ContractorTrackerDto> Edit(ContractorTrackerDto item)
        {
            try
            {
                var contractorTracker = _modelMapper.Map<ContractorTracker>(item);
                var updatedRecord = await _contractorTrackerRepository.Edit(contractorTracker);
                return _modelMapper.Map<ContractorTrackerDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ContractorTrackerDto>> GetAll()
        {
            try
            {
                var contractorTrackers = await _contractorTrackerRepository.GetAll();
                return _modelMapper.Map<List<ContractorTrackerDto>>(contractorTrackers);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ContractorTrackerDto> GetById(long id)
        {
            try
            {
                var contractorTracker = await _contractorTrackerRepository.GetById(id);
                return _modelMapper.Map<ContractorTrackerDto>(contractorTracker);
            }
            catch
            {
                throw;
            }
        }

        public Task<ContractorTrackerDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
