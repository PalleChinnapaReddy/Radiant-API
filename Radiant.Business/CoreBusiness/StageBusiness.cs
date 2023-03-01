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
    public class StageBusiness : IStageBusiness
    {
        private readonly IStageRepository _stageRepository;
        private readonly ILogger<StageBusiness> _logger;
        private readonly IMapper _modelMapper;

        public StageBusiness(IStageRepository stageRepository
            , ILogger<StageBusiness> logger
            , IMapper modelMapper)
        {
            _stageRepository = stageRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<StageDto> Create(StageDto item)
        {
            try
            {
                return _modelMapper.Map<StageDto>(await _stageRepository.Create(_modelMapper.Map<Stage>(item)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                await _stageRepository.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<StageDto> Edit(StageDto item)
        {
            try
            {

                return _modelMapper.Map<StageDto>(await _stageRepository.Edit(_modelMapper.Map<Stage>(item)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<StageDto>> GetAll()
        {
            try
            {

                return _modelMapper.Map<List<StageDto>>(await _stageRepository.GetAll());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<StageDto> GetById(long id)
        {
            try
            {

                return _modelMapper.Map<StageDto>(await _stageRepository.GetById(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<StageDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StageDto>> GetStageByDeptAndLine(long deptId, long subdeptId, long lineId)
        {
            try
            {
                return _modelMapper.Map<List<StageDto>>(await _stageRepository.GetStageByDeptAndLine(deptId, subdeptId, lineId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<StageDto>> GetStageByLine(long lineId)
        {
            try
            {
                return _modelMapper.Map<List<StageDto>>(await _stageRepository.GetStageLine(lineId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
