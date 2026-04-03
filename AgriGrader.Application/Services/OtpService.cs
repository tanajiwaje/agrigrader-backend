using AgriGrader.Application.DTOs;
using AgriGrader.Application.Interfaces;
using AgriGrader.Core.Entities;
using AgriGrader.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriGrader.Application.Services
{
    public class OtpService : IOtpService
    {
        private readonly IOtpRepository _otpRepository;
        private readonly IFirebaseOtpService _firebaseOtpService;
        private readonly ICustomerRepository _userRepository;

        public OtpService(IOtpRepository otpRepository, IFirebaseOtpService firebaseOtpService,ICustomerRepository userRepository)
        {
            _otpRepository = otpRepository;
            _firebaseOtpService = firebaseOtpService;
            _userRepository = userRepository;
        }
        public async Task<bool> SendOtpAsync(string mobileNumber)
        {
            var otp=new Random().Next(100000, 999999).ToString();
            var otpEntity = new OtpVerification
            {
                MobileNumber = mobileNumber,
                Otp = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5),
              
            };

            await _otpRepository.AddAsync(otpEntity);
            await _firebaseOtpService.SendOtpToFirebaseAsync(mobileNumber, otp);
            // Here you would integrate with an SMS gateway to send the OTP to the user's mobile number.
            Console.WriteLine($"OTP for {mobileNumber}: {otp}"); // For demonstration purposes only. Remove in production.

            return true;
        }

        //public async Task<bool> VerifyOtpAsync(string mobileNumber, string otp)
        //{
        //   var records = await _otpRepository.GetValidOtpAsync(mobileNumber, otp);


        //    if (records == null)
        //    {
        //        return records;

        //    }
        //    records.isUsed = true;
        //    return true;
        //}

        public async Task<AuthResponseDto> VerifyOtpAsync(string mobileNumber, string otp)
        {
            var record = await _otpRepository.GetValidOtpAsync(mobileNumber, otp);

            if (record == null)
            {
                return new AuthResponseDto
                {
                    isSuccess = false,
                    isNewUser = false,
                    Message = "Invalid or expired OTP",
                    Token = string.Empty
                };
            }

            record.isUsed = true;
          ///  await _otpRepository.UpdateAsync(record);

           var user = await _userRepository.GetByMobileNumberAsync(mobileNumber);

            bool isNewUser = user == null;
           /// bool isNewUser = user == null;

            string token = string.Empty;

            if (!isNewUser)
            {
                token = "generate-jwt-token-here";
            }

            return new AuthResponseDto
            {
                isSuccess = true,
                isNewUser = isNewUser,
                Message = "OTP verified successfully",
                Token = token
            };
        }
    }
}
