using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Core.Entities
{
    public class OtpVerification
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string Otp { get; set; }
        public DateTime ExpiryTime { get; set; }
        public bool isUsed { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
