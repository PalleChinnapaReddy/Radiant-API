using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class LineBusiness : ILineBusiness
    {
        private readonly ILineRepository _lineRepository;
        private readonly ILogger<LineBusiness> _logger;
        private readonly IMapper _modelMapper;

        public LineBusiness(ILineRepository lineRepository
            , ILogger<LineBusiness> logger
            , IMapper modelMapper)
        {
            _lineRepository = lineRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<LineDto> Create(LineDto item)
        {
            try
            {
                var line = _modelMapper.Map<Line>(item);
                var createdRecord = await _lineRepository.Create(line);
                return _modelMapper.Map<LineDto>(createdRecord);
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
                await _lineRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<LineDto> Edit(LineDto item)
        {
            try
            {
                var line = _modelMapper.Map<Line>(item);
                var updatedRecord = await _lineRepository.Edit(line);
                return _modelMapper.Map<LineDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<LineDto>> GetAll()
        {
            try
            {
                var lines = await _lineRepository.GetAll();
                return _modelMapper.Map<List<LineDto>>(lines);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LineDto> GetById(long id)
        {
            try
            {
                var line = await _lineRepository.GetById(id);
                return _modelMapper.Map<LineDto>(line);
            }
            catch
            {
                throw;
            }
        }

        public async Task<LineDto> GetByName(string name)
        {
            try
            {
                var line = await _lineRepository.GetByName(name);
                return _modelMapper.Map<LineDto>(line);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<LineDto>> GetLineByDept(long deptId, long subdeptId)
        {
            try
            {
                var lines = await _lineRepository.GetLineByDept(deptId, subdeptId);
                return _modelMapper.Map<List<LineDto>>(lines);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DropdownValueDto>> GetLinesDDValues()
        {
            try
            {
                var lines = await _lineRepository.GetLinesDDValues();
                return _modelMapper.Map<List<DropdownValueDto>>(lines);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LinesDashboardDto>> GetAllLines()
        {
            try
            {
                var lines = await _lineRepository.GetLinesDashboards();
                return _modelMapper.Map<List<LinesDashboardDto>>(lines);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
