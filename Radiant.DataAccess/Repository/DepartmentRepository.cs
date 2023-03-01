using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ILogger<Department> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public DepartmentRepository(ILogger<Department> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Department> Create(Department record)
        {
            if (record.Parentdepartmentid != null)
            {
                var dlm = new Departmentlinemapping();
                dlm.Parentdepartmentid = record.Parentdepartmentid;
                dlm.Startdate = DateTime.Now.Date;
                record.DepartmentlinemappingSubdepartment.Add(dlm);
            }
            await _dbContext.Department.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            await UpdateDlMappings();
            return record;
        }

        public async Task Delete(long id)
        {
            var department = await GetById(id);
            department.Isactive = false;
            if (department.Parentdepartmentid == null)
            {
                var subdepartments = await GetByParent(department.Departmentid);
                subdepartments.ForEach((sub) =>
                {
                    sub.Isactive = false;
                    sub.UpdatedOn = DateTime.Now;
                });
                _dbContext.Department.UpdateRange(subdepartments);

            }
            _dbContext.Department.Update(department);
            await _dbContext.SaveChangesAsync();
            await UpdateDlMappings();
        }

        public async Task<Department> Edit(Department record)
        {
            _dbContext.Department.Update(record);
            await _dbContext.SaveChangesAsync();
            await UpdateDlMappings();
            return record;
        }

        private async Task UpdateDlMappings()
        {
            var command = _dbContext.SqlWithStatusText.FromSqlRaw("SELECT * from public.syncdlmmappings()");
            await command.ToListAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Department>> GetAll()
        {
            return await _dbContext.Department.Where(d => d.Isactive == true)
                .OrderByDescending(c => c.Departmentdescription)
                .AsNoTracking()
                .Include((d) => d.EmployeeCurrentDepartment)
                .Include((d) => d.EmployeeSubdepartment)
            .ToListAsync();
        }

        public async Task<Department> GetById(long id)
        {
            return await _dbContext.Department.AsNoTracking().
                Include((d) => d.EmployeeCurrentDepartment).Include((d) => d.EmployeeSubdepartment)
                .FirstOrDefaultAsync(x => x.Departmentid == id);
        }

        public async Task<Department> GetByName(string name)
        {
            return await _dbContext.Department.AsNoTracking()
                .Include(d => d.DepartmentlinemappingSubdepartment)
                .ThenInclude(l => l.Subdepartment)
                .FirstOrDefaultAsync(x => x.Isactive == true &&
                x.Departmentdescription != null && x.Departmentdescription.ToLower() == name.ToLower());
        }

        public async Task<long?> GetLineIdFromMapping(long departmentId)
        {
            var depLineMapping = await _dbContext.Departmentlinemapping.AsNoTracking()
                .FirstOrDefaultAsync(d => d.Isactive == true && (d.Parentdepartmentid == departmentId || d.Subdepartmentid == departmentId));
            return depLineMapping?.Lineid;
        }

        public async Task<List<Department>> GetByParent(long? parentId)
        {
            return await _dbContext.Department.AsNoTracking().Where(x => x.Isactive == true && x.Parentdepartmentid == parentId).ToListAsync();
        }

        public async Task<List<DepartmentWiseAttendanceReport>> GetDepartmentWiseReport(DateTime date)
        {
            var command = _dbContext.DepartmentWiseAttendanceReport.FromSqlRaw($@"
            SELECT * from public.currentdayActualvsAttendancereport('{date.ToString("yyyy-MM-dd")}')");
            return await command.ToListAsync();
        }
    }
}
