using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Application.DTOs
{
   public class CreateCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string FirmName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
