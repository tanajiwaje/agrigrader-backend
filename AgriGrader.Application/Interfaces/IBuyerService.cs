using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgriGrader.Core.DTOs;

namespace AgriGrader.Application.Interfaces
{
    public interface IBuyerService
    {
        Task<IEnumerable<BuyerDto>> GetAllBuyersAsync();
        Task<BuyerDto?> GetBuyerByIdAsync(int id);
        Task AddBuyerAsync(BuyerDto buyerDto);
        Task UpdateBuyerAsync(BuyerDto buyerDto);
        Task DeleteBuyerAsync(int id);
    }
}
