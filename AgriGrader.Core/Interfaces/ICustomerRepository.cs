using AgriGrader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> AddAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task updateAsync(Customer customer);
        Task DeleteAsync(Customer customer);

        Task<Customer> GetByMobileNumberAsync(string mobileNumber);
        Task<(List<Customer>, int)> GetPagedAsync(int pageNumber, int pageSize);

       Task<Customer> GetByEmailAsync(string email);
    }
}
