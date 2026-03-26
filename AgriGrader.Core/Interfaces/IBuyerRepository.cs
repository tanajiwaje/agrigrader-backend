using AgriGrader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Core.Interfaces
{
    public interface IBuyerRepository
    {
        Task<IEnumerable<Buyer>> GetAllAsync();
        Task<Buyer?> GetByIdAsync(int id);
        Task AddAsync(Buyer buyer);
        Task UpdateAsync(Buyer buyer);
        Task DeleteAsync(int id);
    }
}
