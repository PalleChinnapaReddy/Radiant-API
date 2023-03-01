using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class MasterDataBusiness:IMasterDataBusiness
    {
        private readonly IMasterDataRepository _masterDataRepository;
        private readonly ILogger<MasterDataBusiness> _logger;
        private readonly IMapper _modelMapper;

        public MasterDataBusiness(IMasterDataRepository masterDataRepository
            , ILogger<MasterDataBusiness> logger
            , IMapper modelMapper)
        {
            _masterDataRepository = masterDataRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<List<AttachmentsDto>> GetAttachments()
        {
            try
            {
                return _modelMapper.Map<List<AttachmentsDto>>(await _masterDataRepository.GetAttachments());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CityDto>> GetCities()
        {
            try
            {
                return _modelMapper.Map<List<CityDto>>(await _masterDataRepository.GetCities());
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MaritalstatusDto>> GetMartialStatus()
        {
            try
            {

                return _modelMapper.Map<List<MaritalstatusDto>>(await _masterDataRepository.GetMartialStatus());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public async Task<List<PaymenttypeDto>> GetPaymenttypes()
        {
            try
            {

                return _modelMapper.Map<List<PaymenttypeDto>>(await _masterDataRepository.GetPaymenttypes());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
