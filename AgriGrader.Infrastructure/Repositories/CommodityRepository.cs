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
    public class CommodityRepository : ICommodityRepository
    {
        private readonly AgrigraderDbContext _context;

        public CommodityRepository(AgrigraderDbContext context) {
            _context = context;
        }
        public async Task AddAsync(Commodity commodity)
        {
            _context.Commodities.Add(commodity);
            await _context.SaveChangesAsync();
        }

      

        public async Task<IEnumerable<Commodity>> GetAllAsync()
        {
            return await _context.Commodities.ToListAsync();
        }

        public async Task<Commodity> GetByIdAsync(int id)
        {
            return await _context.Commodities.FindAsync(id);
        }

       

        public async Task<(List<Commodity>, int)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.Commodities.AsQueryable();
            var totalCount = await query.CountAsync();

            var data = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (data, totalCount);
        }

        public async Task saveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void updateAsync(Commodity commodity)
        {
            _context.Commodities.Update(commodity);
        }


        public void DeleteAsync(Commodity commodity)
        {
            _context.Commodities.Remove(commodity);
        }
    }
}
