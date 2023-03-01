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
    public class ScreensBusiness : IScreensBusiness
    {
        private readonly IScreensRepository _screensRepository;
        private readonly ILogger<ScreensBusiness> _logger;
        private readonly IMapper _modelMapper;

        public ScreensBusiness(IScreensRepository ScreensRepository
            , ILogger<ScreensBusiness> logger
            , IMapper modelMapper)
        {
            _screensRepository = ScreensRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<ScreensDto> Create(ScreensDto item)
        {
            try
            {
                var screens = _modelMapper.Map<Screens>(item);
                var createdRecord = await _screensRepository.Create(screens);
                return _modelMapper.Map<ScreensDto>(createdRecord);
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
                await _screensRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ScreensDto> Edit(ScreensDto item)
        {
            try
            {
                var screens = _modelMapper.Map<Screens>(item);
                var updatedRecord = await _screensRepository.Edit(screens);
                return _modelMapper.Map<ScreensDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ScreensDto>> GetAll()
        {
            try
            {
                var screens = await _screensRepository.GetAll();
                return _modelMapper.Map<List<ScreensDto>>(screens);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ScreensDto> GetById(long id)
        {
            try
            {
                var screens = await _screensRepository.GetById(id);
                return _modelMapper.Map<ScreensDto>(screens);
            }
            catch
            {
                throw;
            }
        }

        public Task<ScreensDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ScreensDto>> GetScreensByIds(List<long> Ids)
        {
            try
            {
                var screens = await _screensRepository.GetScreensByIds(Ids);
                return _modelMapper.Map<List<ScreensDto>>(screens);
            }
            catch
            {
                throw;
            }
        }
    }
}



