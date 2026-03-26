using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Core.Entities
{
   public class Commodity
    {
     
        
            public int Id { get; set; }
            public string CommodityCode { get; set; }
            public string CommodityName { get; set; }

            public ICollection<SubCommodity> SubCommodities { get; set; }

        
    }
}
