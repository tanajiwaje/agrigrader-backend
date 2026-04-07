using AgriGrader.Application.DTOs;
using AgriGrader.Application.Interfaces;
using AgriGrader.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgriGrader.Core.Entities;
using Newtonsoft.Json.Converters;
using Google.Apis.Upload;

namespace AgriGrader.Application.Services
{
   public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerDto> AddAsync(CreateCustomerDto dto)
        {
            var customers = await _repository.GetAllAsync();
            int nextNumber = customers.Count + 1;

            var customer = new Customer
            {
                UserCode = $"USR-{nextNumber}",
                FirstName = dto.FirmName,
                LastName = dto.LastName,
                FirmName = dto.FirmName,
                MobileNumber = dto.MobileNumber,
                Email = dto.Email,
                RoleId = dto.RoleId
            };

            await _repository.AddAsync(customer);

            return new CustomerDto
            {
                Id = customer.Id,
                UserCode = customer.UserCode,
                FirmName = customer.FirmName,
                FirstName = customer.FirmName,
                LastName = customer.LastName,
                MobileNumber = customer.MobileNumber,
                Email = customer.Email,
                RoleId = customer.RoleId
            };
        }

        public async Task DeleteAsync(int id)
        {
            var c = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(c);
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customer = await _repository.GetAllAsync();

            return customer.Select(c => new CustomerDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                FirmName = c.FirmName,
                MobileNumber = c.MobileNumber,
                Email = c.Email,
                RoleId = c.RoleId
            }).ToList();
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var c = await _repository.GetByIdAsync(id);

            return new CustomerDto
            {
                Id = c.Id,
                UserCode = c.UserCode,
                FirstName = c.FirstName,
                LastName = c.LastName,
                FirmName = c.FirmName,
                MobileNumber = c.MobileNumber,
                Email = c.Email,
                RoleId = c.RoleId
            };
        }

        public Task updateAsync(int id, CreateCustomerDto dto)
        {
            throw new NotImplementedException();
        }

       public async Task<PagedResult<CustomerDto>> GetAllPaginationAsync(int pageNumber, int pageSize)
        {
            var (customers, totalCount) = await _repository.GetPagedAsync(pageNumber, pageSize);

            var data = customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                FirmName = c.FirmName,
                MobileNumber = c.MobileNumber,
                Email = c.Email,
                RoleId = c.RoleId
            }).ToList();

            return new PagedResult<CustomerDto>
            {
                Data = data,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };
        }
   
    }
}
