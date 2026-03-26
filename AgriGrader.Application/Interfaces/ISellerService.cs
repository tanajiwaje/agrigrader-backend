using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgriGrader.Core.DTOs;

namespace AgriGrader.Application.Interfaces
{
    public interface ISellerService
    {
        Task<IEnumerable<SellerDto>> GetAllSellersAsync();
        Task AddSellerAsync(SellerDto sellerDto);
    }
}
