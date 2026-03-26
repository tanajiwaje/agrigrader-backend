using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AgriGrader.Core.Entities;
using AgriGrader.Core.Interfaces;
using AgriGrader.Application.Interfaces;

using System.Security.AccessControl;
using AgriGrader.Application.DTOs;

namespace AgriGrader.Application.Services
{
   public class CommodityService : ICommodityService
    {
        private readonly ICommodityRepository _repository;

        public CommodityService(ICommodityRepository repository)
        {
            _repository = repository;
        }
        public async Task<CommodityDto>  AddAsync(CreateCommodityDto dto)
        {
            var commodity = new Commodity
            {
                CommodityName = dto.CommodityName
            };

            await _repository.AddAsync(commodity);
            return new CommodityDto
            {
                Id = commodity.Id,
                CommodityCode = commodity.CommodityCode,
                CommodityName = commodity.CommodityName
            };
        }

        public async Task<IEnumerable<Commodity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
