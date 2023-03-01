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
    public class SsntypeBusiness : IGenericBusiness<SsntypeDto>
    {
        private readonly IGenericRepository<Ssntype> _SsntypeRepository;
        private readonly ILogger<SsntypeBusiness> _logger;
        private readonly IMapper _modelMapper;

        public SsntypeBusiness(IGenericRepository<Ssntype> SsntypeRepository
            , ILogger<SsntypeBusiness> logger
            , IMapper modelMapper)
        {
            _SsntypeRepository = SsntypeRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<SsntypeDto> Create(SsntypeDto item)
        {
            try
            {
                var Ssntype = _modelMapper.Map<Ssntype>(item);
                var createdRecord = await _SsntypeRepository.Create(Ssntype);
                return _modelMapper.Map<SsntypeDto>(createdRecord);
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
                await _SsntypeRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SsntypeDto> Edit(SsntypeDto item)
        {
            try
            {
                var Ssntype = _modelMapper.Map<Ssntype>(item);
                var updatedRecord = await _SsntypeRepository.Edit(Ssntype);
                return _modelMapper.Map<SsntypeDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<SsntypeDto>> GetAll()
        {
            try
            {
                var Ssntypes = await _SsntypeRepository.GetAll();
                return _modelMapper.Map<List<SsntypeDto>>(Ssntypes);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SsntypeDto> GetById(long id)
        {
            try
            {
                var Ssntype = await _SsntypeRepository.GetById(id);
                return _modelMapper.Map<SsntypeDto>(Ssntype);
            }
            catch
            {
                throw;
            }
        }

        public Task<SsntypeDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}



