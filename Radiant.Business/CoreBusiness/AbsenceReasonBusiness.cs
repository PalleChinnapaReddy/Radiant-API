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
    public class AbsenceReasonBusiness : IGenericBusiness<AbsenceReasonDto>
    {
        private readonly IGenericRepository<AbsenceReason> _absenceReasonRepository;
        private readonly ILogger<AbsenceReasonBusiness> _logger;
        private readonly IMapper _modelMapper;

        public AbsenceReasonBusiness(IGenericRepository<AbsenceReason> absenceReasonRepository
            , ILogger<AbsenceReasonBusiness> logger
            , IMapper modelMapper)
        {
            _absenceReasonRepository = absenceReasonRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<AbsenceReasonDto> Create(AbsenceReasonDto item)
        {
            try
            {
                var absenceReason = _modelMapper.Map<AbsenceReason>(item);
                var createdRecord = await _absenceReasonRepository.Create(absenceReason);
                return _modelMapper.Map<AbsenceReasonDto>(createdRecord);
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
                await _absenceReasonRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<AbsenceReasonDto> Edit( AbsenceReasonDto item)
        {
            try
            {
                var absenceReason = _modelMapper.Map<AbsenceReason>(item);
                var updatedRecord = await _absenceReasonRepository.Edit( absenceReason);
                return _modelMapper.Map<AbsenceReasonDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<AbsenceReasonDto>> GetAll()
        {
            try
            {
                var absenceReasons = await _absenceReasonRepository.GetAll();
                return _modelMapper.Map<List<AbsenceReasonDto>>(absenceReasons);
            }
            catch
            {
                throw;
            }
        }

        public async Task<AbsenceReasonDto> GetById(long id)
        {
            try
            {
                var absenceReason = await _absenceReasonRepository.GetById(id);
                return _modelMapper.Map<AbsenceReasonDto>(absenceReason);
            }
            catch
            {
                throw;
            }
        }

        public Task<AbsenceReasonDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
