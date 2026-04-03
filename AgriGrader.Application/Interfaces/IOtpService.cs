using AgriGrader.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Application.Interfaces
{
   public  interface IOtpService
    {
        Task<bool> SendOtpAsync(string mobileNumber);
        Task<AuthResponseDto> VerifyOtpAsync(string mobileNumber, string otp);
    }
}
