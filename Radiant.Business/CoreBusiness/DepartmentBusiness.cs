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
    public class DepartmentBusiness : IDepartmentBusiness
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<DepartmentBusiness> _logger;
        private readonly IMapper _modelMapper;

        public DepartmentBusiness(IDepartmentRepository departmentRepository
            , ILogger<DepartmentBusiness> logger
            , IMapper modelMapper)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<DepartmentDto> Create(DepartmentDto item)
        {
            try
            {
                var department = _modelMapper.Map<Department>(item);
                var createdRecord = await _departmentRepository.Create(department);
                return _modelMapper.Map<DepartmentDto>(createdRecord);
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
                await _departmentRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DepartmentDto> Edit(DepartmentDto item)
        {
            try
            {
                var department = _modelMapper.Map<Department>(item);
                var updatedRecord = await _departmentRepository.Edit(department);
                return _modelMapper.Map<DepartmentDto>(updatedRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DepartmentDto>> GetAll()
        {
            try
            {
                var departments = await _departmentRepository.GetAll();
                return _modelMapper.Map<List<DepartmentDto>>(departments);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DepartmentDto> GetById(long id)
        {
            try
            {
                var department = await _departmentRepository.GetById(id);
                return _modelMapper.Map<DepartmentDto>(department);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DepartmentDto> GetByName(string name)
        {
            try
            {
                var department = await _departmentRepository.GetByName(name);
                return _modelMapper.Map<DepartmentDto>(department);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DepartmentDto>> GetByParent(int? parentId)
        {
            try
            {
                var departments = await _departmentRepository.GetByParent(parentId);
                return _modelMapper.Map<List<DepartmentDto>>(departments);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DepartmentWiseAttendanceReportDto>> GetDepartmentWiseReport(DateTime date)
        {
            try
            {
                var departmentWiseAttendanceReport = await _departmentRepository.GetDepartmentWiseReport(date);
                return _modelMapper.Map<List<DepartmentWiseAttendanceReportDto>>(departmentWiseAttendanceReport);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long?> GetLineIdFromMapping(long departmentId)
        {
            try
            {
                return await _departmentRepository.GetLineIdFromMapping(departmentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
