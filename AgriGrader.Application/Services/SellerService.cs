using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgriGrader.Core.DTOs;
using AgriGrader.Core.Entities;
using AgriGrader.Core.Interfaces;
using AgriGrader.Application.Interfaces;

namespace AgriGrader.Application.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _repository;

        public SellerService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SellerDto>> GetAllSellersAsync()
        {
            var sellers = await _repository.GetAllSellersAsync();
            return sellers.Select(s => new SellerDto { Name = s.Name, Email = s.Email }).ToList();
        }

        public async Task AddSellerAsync(SellerDto sellerDto)
        {
            var seller = new Seller { Name = sellerDto.Name, Email = sellerDto.Email };
            await _repository.AddSellerAsync(seller);
        }


    }
}
