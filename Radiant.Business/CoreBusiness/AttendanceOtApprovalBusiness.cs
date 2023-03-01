using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using Radiant.Business.Models.Response;
using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class AttendanceOtApprovalBusiness : IAttendanceOTApprovalBusiness
    {
        private readonly IAttendanceOTApprovalRepository _attendanceOtApprovalRepository;
        private readonly ILogger<AttendanceOtApprovalBusiness> _logger;
        private readonly IMapper _modelMapper;

        public AttendanceOtApprovalBusiness(IAttendanceOTApprovalRepository attendanceOtApprovalRepository
            , ILogger<AttendanceOtApprovalBusiness> logger
            , IMapper modelMapper)
        {
            _attendanceOtApprovalRepository = attendanceOtApprovalRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }
        public async Task<AttendanceOtApprovalDto> Create(AttendanceOtApprovalDto item)
        {
            try
            {
                return _modelMapper.Map<AttendanceOtApprovalDto>(await _attendanceOtApprovalRepository.Create(_modelMapper.Map<AttendanceOtApproval>(item)));
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
                await _attendanceOtApprovalRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AttendanceOtApprovalDto> Edit(AttendanceOtApprovalDto item)
        {
            try
            {
                return _modelMapper.Map<AttendanceOtApprovalDto>(await _attendanceOtApprovalRepository.Edit(_modelMapper.Map<AttendanceOtApproval>(item)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AttendanceOtApprovalDto>> GetAll()
        {
            try
            {
                return _modelMapper.Map<List<AttendanceOtApprovalDto>>(await _attendanceOtApprovalRepository.GetAll());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AttendanceOtApprovalDto> GetById(long id)
        {
            try
            {
                return _modelMapper.Map<AttendanceOtApprovalDto>(await _attendanceOtApprovalRepository.GetById(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<AttendanceOtApprovalDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<AttendanceOTApprovalResponseDto> GetRequestsByManagerId(AttendanceOtSearchDto searchDto)
        {
            try
            {
                var filterModel = _modelMapper.Map<AttendanceOtSearch>(searchDto);
                return _modelMapper.Map<AttendanceOTApprovalResponseDto>(await _attendanceOtApprovalRepository.GetRequestsByManagerId(filterModel));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }
    }
}
