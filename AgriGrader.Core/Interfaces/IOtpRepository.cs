using AgriGrader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Core.Interfaces
{
    public interface IOtpRepository
    {
        Task AddAsync(OtpVerification otp);

        Task<OtpVerification> GetValidOtpAsync(string mobilenumber,string otp);


    }
}
