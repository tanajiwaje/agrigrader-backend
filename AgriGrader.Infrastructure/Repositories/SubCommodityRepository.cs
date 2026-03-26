using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgriGrader.Core.Entities;
using AgriGrader.Core.Interfaces;
using AgriGrader.Infrastructure.Data;

namespace AgriGrader.Infrastructure.Repositories
{
    public class SubCommodityRepository : ISubCommodityRepository
    {
        private readonly AgrigraderDbContext _context;

        public SubCommodityRepository(AgrigraderDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SubCommodity subCommodity)
        {
            _context.SubCommodities.Add(subCommodity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SubCommodity>> GetAllAsync()
        {
            return await _context.SubCommodities.Include(s => s.Commodity).ToListAsync();


        }
    }
}
