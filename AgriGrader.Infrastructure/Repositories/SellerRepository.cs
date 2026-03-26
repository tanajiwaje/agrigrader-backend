using AgriGrader.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgriGrader.Core.Entities;
using AgriGrader.Infrastructure.Repositories;
using AgriGrader.Core.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace AgriGrader.Infrastructure.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly AgrigraderDbContext _context;

        public SellerRepository(AgrigraderDbContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Seller>> GetAllSellersAsync()
        //{
        //    return await _context.Sellers.ToListAsync();
        //}

        public async Task<Seller> GetSellerByIdAsync(int id)
        {
            return await _context.Sellers.FindAsync(id);
        }

        public async Task AddSellerAsync(Seller seller)
        {
            await _context.Sellers.AddAsync(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Seller>> GetAllSellersAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

 
        public async Task UpdateAsync(Seller seller)
        {
            _context.Sellers.Update(seller);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);
            if (seller != null)
            {
                _context.Sellers.Remove(seller);
                await _context.SaveChangesAsync();
            }
        }
    }
}
