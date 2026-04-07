using AgriGrader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Core.Interfaces
{
    public interface  ICommodityRepository
    {
        Task<IEnumerable<Commodity>> GetAllAsync();
            Task<Commodity> GetByIdAsync(int id);
        Task AddAsync(Commodity commodity);
        Task<(List<Commodity>, int)> GetPagedAsync(int pageNumber, int pageSize);

        void updateAsync(Commodity commodity);
        void DeleteAsync(Commodity commodity);

        Task saveChangesAsync();


    }
}
