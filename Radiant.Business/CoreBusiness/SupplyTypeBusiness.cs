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
    public class SupplyTypeBusiness : IGenericBusiness<SupplyTypeDto>
    {
        private readonly IGenericRepository<SupplyType> _supplyTypeRepository;
        private readonly ILogger<SupplyTypeBusiness> _logger;
        private readonly IMapper _modelMapper;

        public SupplyTypeBusiness(IGenericRepository<SupplyType> supplyTypeRepository
            , ILogger<SupplyTypeBusiness> logger
            , IMapper modelMapper)
        {
            _supplyTypeRepository = supplyTypeRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<SupplyTypeDto> Create(SupplyTypeDto item)
        {
            try
            {
                var supplyType = _modelMapper.Map<SupplyType>(item);
                var createdRecord = await _supplyTypeRepository.Create(supplyType);
                return _modelMapper.Map<SupplyTypeDto>(createdRecord);
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
                await _supplyTypeRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SupplyTypeDto> Edit(SupplyTypeDto item)
        {
            try
            {
                var supplyType = _modelMapper.Map<SupplyType>(item);
                var updatedRecord =await _supplyTypeRepository.Edit(supplyType);
                return _modelMapper.Map<SupplyTypeDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<SupplyTypeDto>> GetAll()
        {
            try
            {
                var supplyTypes = await _supplyTypeRepository.GetAll();
                return _modelMapper.Map<List<SupplyTypeDto>>(supplyTypes);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SupplyTypeDto> GetById(long id)
        {
            try
            {
                var supplyType = await _supplyTypeRepository.GetById(id);
                return _modelMapper.Map<SupplyTypeDto>(supplyType);
            }
            catch
            {
                throw;
            }
        }

        public Task<SupplyTypeDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

