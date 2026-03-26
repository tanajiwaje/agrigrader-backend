using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Application.DTOs
{
   public class VerifyOtpRequestDto
    {
        public string MobileNumber { get; set; }
        public string Otp { get; set; }
    }
}
