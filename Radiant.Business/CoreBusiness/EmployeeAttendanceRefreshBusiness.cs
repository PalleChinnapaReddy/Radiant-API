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
    public class EmployeeAttendanceRefreshBusiness : IEmployeeAttendanceRefreshBusiness
    {
        private readonly IEmployeeAttendanceRefreshRepository _employeeAttendanceRefreshRepository;
        private readonly ILogger<EmployeeAttendanceRefreshBusiness> _logger;
        private readonly IMapper _modelMapper;

        public EmployeeAttendanceRefreshBusiness(IEmployeeAttendanceRefreshRepository employeeAttendanceRefreshRepository
            , ILogger<EmployeeAttendanceRefreshBusiness> logger
            , IMapper modelMapper)
        {
            _employeeAttendanceRefreshRepository = employeeAttendanceRefreshRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

      

        public async Task<bool> RefreshPostGreAttendance(List<EmployeeattendancerefreshDto> employeeattendancerefreshList)
        {
            try
            {
                var employeeattendancerefreshes = _modelMapper.Map<List<Employeeattendancerefresh>>(employeeattendancerefreshList);
                bool isAdded = await _employeeAttendanceRefreshRepository.RefreshPostGreAttendance(employeeattendancerefreshes);
                return isAdded;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
