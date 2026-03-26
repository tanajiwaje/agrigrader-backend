using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgriGrader.Application.Interfaces;
using AgriGrader.Core.DTOs;
using AgriGrader.Core.Entities;
using AgriGrader.Core.Interfaces;

namespace AgriGrader.Application.Services
{
   public class BuyerService : IBuyerService
    {

        private readonly IBuyerRepository _repository;

        public BuyerService(IBuyerRepository repository)
        {
            _repository = repository;
        }

        public async Task AddBuyerAsync(BuyerDto buyerDto)
        {
            var buyer = new Buyer
            {
                
                Name = buyerDto.Name,
                Mobile = buyerDto.Mobile,
                Address=buyerDto.Address

            };

            await _repository.AddAsync(buyer);


            
        }

        public async Task DeleteBuyerAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BuyerDto>> GetAllBuyersAsync()
        {
            var buyers = await _repository.GetAllAsync();
            return buyers.Select(b => new BuyerDto
            {

                Id = b.Id,
                Name = b.Name,
                Mobile = b.Mobile,
                Address = b.Address
            });
        }

        public async Task<BuyerDto?> GetBuyerByIdAsync(int id)
        {
            var buyer = await _repository.GetByIdAsync(id);
            if (buyer == null) return null;

            return new BuyerDto
            {
                Id = buyer.Id,
                Name = buyer.Name,
                Mobile = buyer.Mobile,
                Address = buyer.Address
            };

        }

        public async Task UpdateBuyerAsync(BuyerDto buyerDto)
        {
            var buyer = new Buyer
            {
                Id = buyerDto.Id,
                Name = buyerDto.Name,
                Mobile = buyerDto.Mobile,
                Address = buyerDto.Address,
            };
            await _repository.UpdateAsync(buyer);
        }
    }
}
