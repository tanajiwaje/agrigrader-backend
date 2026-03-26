using AgriGrader.Application.Interfaces;
using AgriGrader.Core.Entities;
using AgriGrader.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Application.Services
{
    public class SubCommodityService : ISubCommodityService
    {

        private readonly ISubCommodityRepository _repository;

        public SubCommodityService(ISubCommodityRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(SubCommodity subCommodity)
        {
            await _repository.AddAsync(subCommodity);

        }

        public async Task<IEnumerable<SubCommodity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
