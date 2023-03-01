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
    public class PlantBusiness : IGenericBusiness<PlantDto>
    {
        private readonly IGenericRepository<Plant> _plantRepository;
        private readonly ILogger<PlantBusiness> _logger;
        private readonly IMapper _modelMapper;

        public PlantBusiness(IGenericRepository<Plant> plantRepository
            , ILogger<PlantBusiness> logger
            , IMapper modelMapper)
        {
            _plantRepository = plantRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<PlantDto> Create(PlantDto item)
        {
            try
            {
                var plant = _modelMapper.Map<Plant>(item);
                var createdRecord = await _plantRepository.Create(plant);
                return _modelMapper.Map<PlantDto>(createdRecord);
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
                await _plantRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PlantDto> Edit(PlantDto item)
        {
            try
            {
                var plant = _modelMapper.Map<Plant>(item);
                var updatedRecord = await _plantRepository.Edit(plant);
                return _modelMapper.Map<PlantDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PlantDto>> GetAll()
        {
            try
            {
                var plants = await _plantRepository.GetAll();
                return _modelMapper.Map<List<PlantDto>>(plants);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PlantDto> GetById(long id)
        {
            try
            {
                var plant = await _plantRepository.GetById(id);
                return _modelMapper.Map<PlantDto>(plant);
            }
            catch
            {
                throw;
            }
        }

        public Task<PlantDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
