using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class ContractorBusiness : ISearchableBusiness<ContractorDto, ContractorSearchDto>
    {
        private readonly ISearchableRepository<Contractor, ContractorSearch> _contractorRepository;
        private readonly ILogger<ContractorBusiness> _logger;
        private readonly IMapper _modelMapper;

        public ContractorBusiness(ISearchableRepository<Contractor, ContractorSearch> contractorRepository
            , ILogger<ContractorBusiness> logger
            , IMapper modelMapper)
        {
            _contractorRepository = contractorRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<ContractorDto> Create(ContractorDto item)
        {
            try
            {
                return _modelMapper.Map<ContractorDto>(await _contractorRepository.Create(_modelMapper.Map<Contractor>(item)));
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task Delete(long id)
        {
            try
            {
                await _contractorRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }

        public async Task<ContractorDto> Edit(ContractorDto item)
        {
            try
            {
                return _modelMapper.Map<ContractorDto>(await _contractorRepository.Edit(_modelMapper.Map<Contractor>(item)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ContractorDto>> GetAll()
        {
            try
            {
                return _modelMapper.Map<List<ContractorDto>>(await _contractorRepository.GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ContractorDto> GetById(long id)
        {
            try
            {
                return _modelMapper.Map<ContractorDto>(await _contractorRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<ContractorDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ContractorDto>> Search(ContractorSearchDto searchDto)
        {
            try
            {
                var contractorSearch = _modelMapper.Map<ContractorSearch>(searchDto);
                return _modelMapper.Map<List<ContractorDto>>(await _contractorRepository.Search(contractorSearch));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
