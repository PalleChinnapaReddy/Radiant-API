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
    public class ProvinceBusiness : IGenericBusiness<ProvinceDto>
    {
        private readonly IGenericRepository<Province> _provinceRepository;
        private readonly ILogger<ProvinceBusiness> _logger;
        private readonly IMapper _modelMapper;

        public ProvinceBusiness(IGenericRepository<Province> provinceRepository
            , ILogger<ProvinceBusiness> logger
            , IMapper modelMapper)
        {
            _provinceRepository = provinceRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }
        public async Task<ProvinceDto> Create(ProvinceDto item)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProvinceDto> Edit(ProvinceDto item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProvinceDto>> GetAll()
        {
            try
            {

                return _modelMapper.Map<List<ProvinceDto>>(await _provinceRepository.GetAll());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProvinceDto> GetById(long id)
        {
            try
            {

                return _modelMapper.Map<ProvinceDto>(await _provinceRepository.GetById(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<ProvinceDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
