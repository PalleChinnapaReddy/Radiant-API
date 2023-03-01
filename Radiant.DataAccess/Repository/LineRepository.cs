using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using Radiant.DataAccess.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class LineRepository : ILineRepository
    {
        private readonly ILogger<Line> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public LineRepository(ILogger<Line> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        private async Task UpdateDlMappings()
        {
            var command = _dbContext.SqlWithStatusText.FromSqlRaw("SELECT * from public.syncdlmmappings()");
            await command.ToListAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Line> Create(Line record)
        {
            if (record.Departmentlinemapping.Count > 0)
            {
                var dlms = record.Departmentlinemapping.Where(dlm => dlm.Isactive == true).ToList();
                dlms.ForEach((dlm) =>
                {
                    dlm.Startdate = DateTime.Now.Date;
                });
            }
            await _dbContext.Line.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            // Need to add Koushik Line Add and delete proc
            await UpdateDlMappings();
            return record;
        }

        public async Task Delete(long id)
        {
            var line = await GetById(id);
            line.Isactive = false;
            _dbContext.Line.Update(line);
            var stages = _dbContext.Stage.Where(x => x.Isactive == true && x.Lineid == id).ToList();
            if (stages.Count() > 0)
            {
                stages.ForEach((s) =>
                {
                    s.Isactive = false;
                    s.UpdatedOn = DateTime.Now;
                });
            }

            // Need to add Koushik Line Add and delete proc
            await _dbContext.SaveChangesAsync();
            await UpdateDlMappings();
        }

        public async Task<Line> Edit(Line record)
        {
            if (record.Departmentlinemapping.Count > 0)
            {
                var dlms = record.Departmentlinemapping.ToList();
                dlms.ForEach((dlm) =>
                {
                    dlm.Startdate = dlm.Departmentlineid == 0 ? DateTime.Now.Date : dlm.Startdate;
                    dlm.Enddate = dlm.Isactive == false ? dlm.Enddate.HasValue ? dlm.Enddate : DateTime.Now.Date : DateTime.MaxValue.Date;
                });
            }
            _dbContext.Line.Update(record);
            await _dbContext.SaveChangesAsync();
            await UpdateDlMappings();
            return record;
        }

        public async Task<List<Line>> GetAll()
        {
            return await _dbContext.Line.
                Where(l => l.Isactive == true)
                .Include(l => l.Employee)
                .Include(c => c.Stage).ThenInclude(c => c.EmployeeAttendance).ThenInclude(a => a.AttendanceType)
                .Include(c => c.Stage).ThenInclude(c => c.EmployeeAttendance).ThenInclude(o => o.AttendanceOtApproval).ThenInclude(s => s.Otstatus)
                .Include(c => c.Departmentlinemapping).ThenInclude(dlm => dlm.Parentdepartment)
                .Include(c => c.Departmentlinemapping).ThenInclude(dlm => dlm.Subdepartment)
                .Include(c => c.Stage).ThenInclude(c => c.Employee)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Line> GetById(long id)
        {
            var line = await _dbContext.Line.AsNoTracking()
                .Include(c => c.Stage)
                .Include(c => c.Departmentlinemapping)
                .FirstOrDefaultAsync(x => x.Lineid == id);
            if (line != null)
            {
                line.Departmentlinemapping = line.Departmentlinemapping.Where(d => d.Isactive == true).ToList();
            }
            return line;
        }

        public async Task<Line> GetByName(string name)
        {
            return await _dbContext.Line
                .Include(c => c.Stage).AsNoTracking()
                .FirstOrDefaultAsync(x => x.Isactive == true &&
                x.Linedescription != null && x.Linedescription.ToLower() == name.ToLower());
        }

        public async Task<List<Line>> GetLineByDept(long deptId, long subdeptId)
        {
            var mappings = await _dbContext.Departmentlinemapping.AsNoTracking()
                .Where((dlm) => dlm.Parentdepartmentid == deptId && dlm.Subdepartmentid == subdeptId)
                .Select(d => d.Lineid)
                .ToListAsync();

            return await _dbContext.Line.AsNoTracking().Where(l => mappings.Contains(l.Lineid)).ToListAsync();
        }

        public async Task<List<LinesDashboard>> GetLinesDashboards()
        {
            var data = new List<LinesDashboard>();
            foreach (var lineModel in await _dbContext.Line.Where(l => l.Isactive == true)
                .Include(c => c.Stage).ThenInclude(c => c.Employee)
                .Include(c => c.Stage).ThenInclude(c => c.EmployeeAttendance).ThenInclude(c => c.AttendanceType)
                .Include(c => c.Stage).ThenInclude(c => c.EmployeeAttendance).ThenInclude(c => c.AttendanceOtApproval).ThenInclude(c => c.Otstatus)
                .ToListAsync())
            {
                var line = new LinesDashboard
                {
                    Lineid = lineModel.Lineid,
                    Linedescription = lineModel.Linedescription,
                    Isactive = true,
                    ActiveEmployeeCount = lineModel.Employee.Where(e => e.Isactive == true).Count(),
                    Stage = lineModel.Stage.Where(s => s.Isactive == true).ToList()

                };
                data.Add(line);
            }

            return data;
        }

        public async Task<List<DropdownValue>> GetLinesDDValues()
        {
            return await _dbContext.Line.AsNoTracking().Where(x => x.Isactive == true)
                .Select(s => new DropdownValue
                {
                    Id = s.Lineid,
                    Name = s.Linedescription,
                }).ToListAsync();

        }
    }
}
