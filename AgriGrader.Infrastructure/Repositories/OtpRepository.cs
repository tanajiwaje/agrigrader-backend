using AgriGrader.Core.Entities;
using AgriGrader.Core.Interfaces;
using AgriGrader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Infrastructure.Repositories
{
    public class OtpRepository : IOtpRepository
    {
        private readonly AgrigraderDbContext _context;

       public OtpRepository(AgrigraderDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(OtpVerification otp)
        {
            await _context.OtpVerifications.AddAsync(otp);
            await _context.SaveChangesAsync();
        }

        public async Task<OtpVerification> GetValidOtpAsync(string mobileNumber, string otp)
        {
            return await _context.OtpVerifications
            .FirstOrDefaultAsync(x =>
                x.MobileNumber == mobileNumber &&
                x.Otp == otp &&
                !x.isUsed &&
                x.ExpiryTime > DateTime.UtcNow);
        }
    }
}
