using AgriGrader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Application.Interfaces
{
    public interface ISubCommodityService
    {
        Task<IEnumerable<SubCommodity>> GetAllAsync();
        Task AddAsync(SubCommodity subCommodity);
    }
}
