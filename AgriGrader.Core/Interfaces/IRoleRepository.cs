using AgriGrader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Core.Interfaces
{
   public interface IRoleRepository
    {
        Task<Role> AddAsync(Role role);
        Task<List<Role>> GetAllAsync();
    }
}
