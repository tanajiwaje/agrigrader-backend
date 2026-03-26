using AgriGrader.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Application.Interfaces
{
   public interface IAuthService
    {
        Task<AuthResponseDto> VerifyOtpAndAuthenticationAsync(VerifyOtpRequestDto dto);
        Task<AuthResponseDto> GoogleLoginAsync(string idToken);
    }
}
