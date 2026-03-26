using AgriGrader.Core.Entities;
using AgriGrader.Core.Interfaces;
using AgriGrader.Infrastructure.Data;
using Google.Apis.Upload;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AgriGrader.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AgrigraderDbContext _context;

        public CustomerRepository(AgrigraderDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

      

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);

        }

        public async Task updateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

    
        public async Task<(List<Customer>, int)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.Customers.AsQueryable();
            var totalCount = await query.CountAsync();

            var data = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (data, totalCount);
        }

        public async Task<Customer> GetByMobileNumberAsync(string mobileNumber)
        {
           return await _context.Customers.FirstOrDefaultAsync(c => c.MobileNumber == mobileNumber);
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
           return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
