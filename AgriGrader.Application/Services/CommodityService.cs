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
using Google.Apis.Upload;

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

            var commodityResp = await _repository.GetAllAsync();
            int nextNumber = commodityResp.Count() + 1;

            var commodity = new Commodity
            {
                CommodityCode = $"CMD-{nextNumber}",
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

        public async Task<PagedResult<CommodityDto>> GetAllPaginationAsync(int pageNumber, int pageSize)
        {
            var (commodites, totalCount) = await _repository.GetPagedAsync(pageNumber, pageSize);

            var data = commodites.Select(c => new CommodityDto
            {
                Id = c.Id,
                CommodityCode=c.CommodityCode,
                CommodityName=c.CommodityName
            }).ToList();

            return new PagedResult<CommodityDto>
            {
                Data = data,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };
        }

        public Task<CommodityDto> GetByIdAsync(int id)
        {
            var result = _repository.GetByIdAsync(id).Result;

            if (result == null)
                return Task.FromResult<CommodityDto>(null);

            CommodityDto dto = new CommodityDto
            {
                Id = result.Id,
                CommodityCode = result.CommodityCode,
                CommodityName = result.CommodityName
            };
            return Task.FromResult(dto);
        }

        public async Task<bool> UpdateAsync(UpdateCommodityDto dto)
        {
           var entity=await _repository.GetByIdAsync(dto.Id);

            if (entity == null)
                return false;

           entity.CommodityName = dto.CommodityName;
            _repository.updateAsync(entity);
            await _repository.saveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity= await _repository.GetByIdAsync(id);

             if(entity == null)
                return false;

            _repository.DeleteAsync(entity);

            await _repository.saveChangesAsync();

            return true;
        }

    }
}
