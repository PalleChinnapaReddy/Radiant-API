using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using Radiant.Business.Models.FilterModels;
using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class EmployeeSkillBusiness : IEmployeeSkillBusiness
    {
        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        private readonly ILogger<EmployeeSkillBusiness> _logger;
        private readonly IMapper _modelMapper;

        public EmployeeSkillBusiness(IEmployeeSkillRepository employeeSkillRepository
            , ILogger<EmployeeSkillBusiness> logger
            , IMapper modelMapper)
        {
            _employeeSkillRepository = employeeSkillRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<EmployeeSkillDto> Create(EmployeeSkillDto item)
        {
            try
            {
                var employeeSkill = _modelMapper.Map<Employeeskill>(item);
                var createdRecord = await _employeeSkillRepository.Create(employeeSkill);
                return _modelMapper.Map<EmployeeSkillDto>(createdRecord);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                await _employeeSkillRepository.Delete(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeSkillDto> Edit(EmployeeSkillDto item)
        {
            try
            {
                var employeeSkill = _modelMapper.Map<Employeeskill>(item);
                var updatedRecord = await _employeeSkillRepository.Edit(employeeSkill);
                return _modelMapper.Map<EmployeeSkillDto>(updatedRecord);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EmployeeSkillDto>> GetAll()
        {
            try
            {
                var employeeSkills = await _employeeSkillRepository.GetAll();
                return _modelMapper.Map<List<EmployeeSkillDto>>(employeeSkills);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeSkillDto> GetById(long id)
        {
            try
            {
                var employeeSkill = await _employeeSkillRepository.GetById(id);
                return _modelMapper.Map<EmployeeSkillDto>(employeeSkill);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EmployeeSkillMatrixDto>> GetEmployeeSkillMatrixByManagerId(EmployeeSkillSearchDto searchDto)
        {
            try
            {
                var filterModel = _modelMapper.Map<EmployeeSkillSearch>(searchDto);
                var updatedRecord = await _employeeSkillRepository.GetEmployeeSkillMatrixByManagerId(filterModel);
                return _modelMapper.Map<List<EmployeeSkillMatrixDto>>(updatedRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UpsertEmpSkillDto>> PostEmpSkill(EmployeeSkillRequestDto employeeSkillRequestDto)
        {
            try
            {
                var employeeSkillRequest = _modelMapper.Map<EmployeeSkillRequest>(employeeSkillRequestDto);
                var empSkills =await _employeeSkillRepository.PostEmpSkill(employeeSkillRequest);
                return _modelMapper.Map<List<UpsertEmpSkillDto>>(empSkills);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EmpSkillDto>> GetEmployeeSkillMatrixByEmployeeId(long employeeId)
        {
            try
            {
                var empSkills = await _employeeSkillRepository.GetEmployeeSkillMatrixByEmployeeId(employeeId);
                return _modelMapper.Map<List<EmpSkillDto>>(empSkills);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<EmployeeSkillDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeSkillSummaryDto>> GetSkillSummaryReport(long? departmentId, long? managerId, DateTime reportDate)
        {
            try
            {
                var empSkillSummaries = await _employeeSkillRepository.GetSkillSummaryReport(departmentId, managerId, reportDate);
                return _modelMapper.Map<List<EmployeeSkillSummaryDto>>(empSkillSummaries);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
