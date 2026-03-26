using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgriGrader.Core.Entities;
using AgriGrader.Core.Interfaces;
using AgriGrader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AgriGrader.Infrastructure.Repositories
{
     public class BuyerRepository : IBuyerRepository
    {
        private readonly AgrigraderDbContext _context;


        public BuyerRepository(AgrigraderDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(Buyer buyer)
        {
            await _context.Buyers.AddAsync(buyer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var buyer = await _context.Buyers.FindAsync(id);

            if (buyer != null)
            {
                _context.Buyers.Remove(buyer);
                await _context.SaveChangesAsync();
            
              }
        }

        public async Task<IEnumerable<Buyer>> GetAllAsync()
        {
            return await _context.Buyers.ToListAsync();
        }

        public async Task<Buyer?> GetByIdAsync(int id)
        {
            return await _context.Buyers.FindAsync(id);
        }

        public async Task UpdateAsync(Buyer buyer)
        {
            _context.Buyers.Update(buyer);
            await _context.SaveChangesAsync();
        }
    }
}
