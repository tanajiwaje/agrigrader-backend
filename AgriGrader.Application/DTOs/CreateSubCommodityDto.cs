using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Application.DTOs
{
    public class CreateSubCommodityDto
    {
        public string SubCommodityName { get; set; }

        public int CommodityId { get; set; }
    }
}
