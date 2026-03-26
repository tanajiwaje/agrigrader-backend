using AgriGrader.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> AddAsync(CreateCustomerDto dto);
        Task<List<CustomerDto>> GetAllAsync();

       Task<PagedResult<CustomerDto>> GetAllPaginationAsync(int pageNumber,int pageSize);

        Task<CustomerDto> GetByIdAsync(int id);
        Task updateAsync(int id, CreateCustomerDto dto);
        Task DeleteAsync(int id);
    }
}
