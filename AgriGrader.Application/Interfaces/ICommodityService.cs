using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgriGrader.Application.DTOs;
using AgriGrader.Application.Interfaces;

using AgriGrader.Core.Entities;
using AgriGrader.Core.Interfaces;


namespace AgriGrader.Application.Interfaces
{
    public interface ICommodityService
    {
        Task<IEnumerable<Commodity>> GetAllAsync();
        Task<CommodityDto> AddAsync(CreateCommodityDto dto);
    }
}
