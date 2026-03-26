using AgriGrader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Core.Interfaces
{
    public interface ISubCommodityRepository
    {
        Task<IEnumerable<SubCommodity>> GetAllAsync();
        Task AddAsync(SubCommodity subCommodity);
    }
}
