using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Application.Interfaces
{
    public interface IFirebaseOtpService
    {
        Task SendOtpToFirebaseAsync(string phoneNumber);
    }
}
