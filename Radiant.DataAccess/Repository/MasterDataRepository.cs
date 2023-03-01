using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class MasterDataRepository : IMasterDataRepository
    {
        private readonly ILogger<MasterDataRepository> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public MasterDataRepository(ILogger<MasterDataRepository> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<List<Maritalstatus>> GetMartialStatus()
        {
            return await _dbContext.Maritalstatus.Where(ms => ms.Isactive == true).OrderBy(ms=>ms.Maritalstatus1).AsNoTracking().ToListAsync();
        }

        public async Task<List<Paymenttype>> GetPaymenttypes()
        {
            return await _dbContext.Paymenttype.Where(pt => pt.Isactive == true).OrderBy(pt=>pt.Paymenttype1).AsNoTracking().ToListAsync();
        }

        public async Task<List<City>> GetCities()
        {
            return await _dbContext.City.Where(c => c.Isactive == true).OrderBy(c=>c.City1).AsNoTracking()
                .Include(c=>c.Province).ThenInclude(c=>c.Country)
                .ToListAsync();
        }

        public async Task<List<Attachments>> GetAttachments()
        {
            return await _dbContext.Attachments.Where(a => a.Isactive == true).OrderBy(c => c.Attachmentsid).AsNoTracking()
                 .ToListAsync();
        }
    }
}