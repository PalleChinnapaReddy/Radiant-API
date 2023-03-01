using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using Radiant.Business.Models.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Radiant.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollBusiness _payrollBusiness;
        private readonly IPayrollDeductionBusiness _payrollDeductionBusiness;
        private readonly ILogger<PayrollController> _logger;
        private readonly IPayrollConfigBusiness _payrollConfigBusiness;
        private readonly string UPLOAD_DIRECTORY =
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Payroll");
        private readonly IEmployeeBusiness _employeeBusiness;
        public PayrollController(IPayrollBusiness payrollBusiness,
            IPayrollDeductionBusiness payrollDeductionBusiness,
            IEmployeeBusiness employeeBusiness,
            IPayrollConfigBusiness payrollConfigBusiness
            , ILogger<PayrollController> logger)
        {
            _payrollBusiness = payrollBusiness;
            _payrollDeductionBusiness = payrollDeductionBusiness;
            _payrollConfigBusiness = payrollConfigBusiness;
            _employeeBusiness = employeeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Payrolls
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<PayrollDto>>> GetAll()
        {
            try
            {
                var payrolls = await _payrollBusiness.GetAll();
                return Ok(payrolls);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Payroll by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<PayrollDto>> GetPayrollById(long id)
        {
            try
            {
                _logger.LogInformation("Get Payroll by id");
                var payroll = await _payrollBusiness.GetById(id);
                return Ok(payroll);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Payroll
        /// </summary>
        /// <param name="payrollDto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PayrollDto payrollDto)
        {
            try
            {
                var createdRecord = await _payrollBusiness.Create(payrollDto);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Payroll
        /// </summary>
        /// <param name="payroll"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditGender([FromBody] PayrollDto payroll)
        {
            try
            {
                var updatedRecord = await _payrollBusiness.Edit(payroll);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Payroll
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteGender(long id)
        {
            try
            {
                await _payrollBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get consolidationbymonth
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("consolidationbymonth")]

        public async Task<ActionResult<List<ConsolidationByMonthDto>>> GetConsolidationByMonth(string contractorId)
        {
            try
            {
                var plants = await _payrollBusiness.GetConsolidationByMonth(contractorId);
                return Ok(plants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Consolidated Attendance by Month
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("consolidatedattendancebymonth")]
        public async Task<ActionResult<ConsolidationAttendanceResponseDto>> GetConsolidationAttendanceByMonth([FromQuery] ConsolidatedAttendanceByMonthFilterDto filter)
        {
            try
            {
                var consolidatedAttendances = await _payrollBusiness.GetConsolidatedAttendanceByMonth(filter);
                return Ok(consolidatedAttendances);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all attendance of that payroll
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("attendancepayroll")]

        public async Task<ActionResult<AttendancePayrollResponseDto>> GetPayrollAttendance([FromQuery] AttendancePayrollFilterDto attendancePayrollFilterDto)
        {
            try
            {
                var attendancePayrollDtos = await _payrollBusiness.GetPayrollAttendance(attendancePayrollFilterDto);
                return Ok(attendancePayrollDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpPost]
        [Route("upload_file")]

        public async Task<ActionResult<bool>> ExcelManipulation([FromForm] long payrollConfigurationId,[FromForm] string folder_name = "")
        {
            try
            {
                List<PayrolldeductionDto> payrolldeductions = new List<PayrolldeductionDto>();
                var dirPath = UPLOAD_DIRECTORY;
                var files = Request.Form.Files;
                List<EmployeeDto> employees = new List<EmployeeDto>();
                if (files.Count == 0)
                {
                    return BadRequest("Atleast one file is expected to upload");
                }
                var fullPath = "";
                foreach (var file in files)
                {
                    bool isRootFolder = string.IsNullOrWhiteSpace(folder_name);
                    var filePath = file.FileName;
                    fullPath = Path.Combine(dirPath, filePath);
                    if (!isRootFolder)
                    {
                        folder_name = folder_name.Replace("/", "\\");
                        filePath = Path.Combine(folder_name, file.FileName);
                    }
                    var isFileExists = System.IO.File.Exists(fullPath);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fullPath, false))
                    //using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fileName, false))
                    {

                        //create the object for workbook part  
                        WorkbookPart wbPart = doc.WorkbookPart;

                        //statement to get the count of the worksheet  
                        int worksheetcount = doc.WorkbookPart.Workbook.Sheets.Count();

                        //statement to get the sheet object  
                        Sheet mysheet = (Sheet)doc.WorkbookPart.Workbook.Sheets.ChildElements.GetItem(0);

                        //statement to get the worksheet object by using the sheet id  
                        Worksheet Worksheet = ((WorksheetPart)wbPart.GetPartById(mysheet.Id)).Worksheet;

                        //Note: worksheet has 8 children and the first child[1] = sheetviewdimension,....child[4]=sheetdata  
                        int wkschildno = 4;


                        //statement to get the sheetdata which contains the rows and cell in table  
                        SheetData Rows = (SheetData)Worksheet.ChildElements.GetItem(wkschildno);

                        foreach (var row in Rows)
                        {
                            if (row.HasChildren &&
                                row.ChildElements.GetItem(0).InnerText != null &&
                                long.Parse(row.ChildElements.GetItem(0).InnerText) != 0)
                            {
                                var employee = new EmployeeDto();
                                employee.Empcode = long.Parse(row.ChildElements.GetItem(0).InnerText);
                                PayrolldeductionDto payrolldeduction = new PayrolldeductionDto();
                                payrolldeduction.Empcode = long.Parse(row.ChildElements.GetItem(0).InnerText);
                                payrolldeduction.Month = row.ChildElements.GetItem(1).InnerText;
                                payrolldeduction.Year = long.Parse(row.ChildElements.GetItem(2).InnerText);
                                payrolldeduction.Subleaderallowance = long.Parse(row.ChildElements.GetItem(3).InnerText);
                                payrolldeduction.Otherallowance = long.Parse(row.ChildElements.GetItem(4).InnerText);
                                payrolldeduction.Miscellaneous = long.Parse(row.ChildElements.GetItem(5).InnerText);
                                payrolldeduction.Refundabledeposit = long.Parse(row.ChildElements.GetItem(6).InnerText);
                                payrolldeduction.Otherdeduction = long.Parse(row.ChildElements.GetItem(7).InnerText);
                                payrolldeduction.Canteendeductions = long.Parse(row.ChildElements.GetItem(8).InnerText);
                                payrolldeduction.Transportdeductions = long.Parse(row.ChildElements.GetItem(9).InnerText);
                                payrolldeduction.Lcmeligible = long.Parse(row.ChildElements.GetItem(10).InnerText);
                                payrolldeductions.Add(payrolldeduction);
                                employees.Add(employee);
                            }
                        }
                    }
                }
                var employeeMissing = _employeeBusiness.GetNewEmployees(employees.Distinct().ToList());
                if (employeeMissing == null || employeeMissing.Count == 0)
                {
                    var payrollConfig =await _payrollConfigBusiness.GetById(payrollConfigurationId);
                    payrollConfig.Payrollstatusid = 3;
                    payrollConfig.Uploadedfilelocation = fullPath;
                    await _payrollDeductionBusiness.UploadEmployeeDeduction(payrolldeductions);
                    await _payrollConfigBusiness.Edit(payrollConfig);
                }
                else
                {
                    var missed = employeeMissing.Select(e => e.Empcode).ToList();
                    string missedEmpCode="";
                    missed.ForEach((e) => missedEmpCode += e + ", ");
                    return BadRequest(String.Format("Following EmployeeIds are not existing {0}", missedEmpCode));
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all attendance of that payroll to review with deductions
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("attendancereviewpayroll")]

        public async Task<ActionResult<PayrollResponseDto>> GetPayrollReviewAttendance([FromQuery] PayrollFilterDto payrollFilterDto)
        {
            try
            {
                var attendancePayrollDtos = await _payrollBusiness.GetReviewPayroll(payrollFilterDto);
                return Ok(attendancePayrollDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }

}

