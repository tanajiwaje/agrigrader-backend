using AgriGrader.Application.DTOs;
using AgriGrader.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgriGrader.Core.Interfaces;
using Google.Apis.Auth;

namespace AgriGrader.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IOtpService _otpService;
        private readonly ICustomerRepository _customerRepository;

        public AuthService(IOtpService otpService, ICustomerRepository customerRepository)
        {
            _otpService = otpService;
            _customerRepository = customerRepository;
        }

        public async Task<AuthResponseDto> GoogleLoginAsync(string idToken)
        {
           var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);

            var user=await _customerRepository.GetByEmailAsync(payload.Email);

            ///if (user == null || user.RoleId !=1)
            if (user == null)
                {
                return new AuthResponseDto
                {
                    isSuccess = false,
                    isNewUser = true,
                    Message = "User not found, Please Register"
                };
            }
            return new AuthResponseDto {
                isSuccess = true,
                Message = "Admin Login successful",
                Token = "Temp_Admin_Token"
            };
        }

        public async Task<AuthResponseDto> VerifyOtpAndAuthenticationAsync(VerifyOtpRequestDto dto)
        {
            var result = await _otpService.VerifyOtpAsync(dto.MobileNumber, dto.Otp);

            if(!result.isSuccess)
            {
                return new AuthResponseDto
                {
                    isSuccess = false,
                    Message = "Invalid OTP."
                };
            }

            var user = await _customerRepository.GetByMobileNumberAsync(dto.MobileNumber);

            if (user == null)
            { 
               return new AuthResponseDto
               {
                   isSuccess = true,
                   isNewUser=true,
                   Message = "User not found, Please Register"

               };
            }

            return new AuthResponseDto
            {
                isSuccess = true,
                isNewUser = false,
                Message = "Authentication successful.",
                Token = "Temp_Token"
            };
        }
    }
}
