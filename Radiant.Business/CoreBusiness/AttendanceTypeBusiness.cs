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
    public class AttendanceTypeBusiness : IGenericBusiness<AttendancetypeDto>
    {
        private readonly IGenericRepository<Attendancetype> _attendanceTypeRepository;
        private readonly ILogger<AttendanceTypeBusiness> _logger;
        private readonly IMapper _modelMapper;

        public AttendanceTypeBusiness(IGenericRepository<Attendancetype> attendanceTypeRepository
            , ILogger<AttendanceTypeBusiness> logger
            , IMapper modelMapper)
        {
            _attendanceTypeRepository = attendanceTypeRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<AttendancetypeDto> Create(AttendancetypeDto item)
        {
            try
            {
                var attendancetype = _modelMapper.Map<Attendancetype>(item);
                var createdRecord = await _attendanceTypeRepository.Create(attendancetype);
                return _modelMapper.Map<AttendancetypeDto>(createdRecord);
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
                await _attendanceTypeRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<AttendancetypeDto> Edit( AttendancetypeDto item)
        {
            try
            {
                var attendancetype = _modelMapper.Map<Attendancetype>(item);
                var updatedRecord = await _attendanceTypeRepository.Edit( attendancetype);
                return _modelMapper.Map<AttendancetypeDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<AttendancetypeDto>> GetAll()
        {
            try
            {
                var absenceReasons = await _attendanceTypeRepository.GetAll();
                return _modelMapper.Map<List<AttendancetypeDto>>(absenceReasons);
            }
            catch
            {
                throw;
            }
        }

        public async Task<AttendancetypeDto> GetById(long id)
        {
            try
            {
                var attendanceType = await _attendanceTypeRepository.GetById(id);
                return _modelMapper.Map<AttendancetypeDto>(attendanceType);
            }
            catch
            {
                throw;
            }
        }

        public Task<AttendancetypeDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
