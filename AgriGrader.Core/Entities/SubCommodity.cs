using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Core.Entities
{
   public class SubCommodity
    {
        public int Id { get; set; }
        public string SubCommodityCode { get; set; }

        public string SubCommodityName { get; set; }
        public int CommodityId { get; set; }
 

        public Commodity? Commodity { get; set; }

    }
}
