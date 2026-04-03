using AgriGrader.Application.DTOs;
using AgriGrader.Application.Interfaces;
using AgriGrader.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace AgriGrader.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OtpController : ControllerBase
    {
        private readonly IFirebaseOtpService _firebaseOtpService;
        private readonly IOtpService _otpService;

        public OtpController(IFirebaseOtpService firebaseOtpService, IOtpService otpService)
        {
            _firebaseOtpService = firebaseOtpService;
            _otpService = otpService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendOtp([FromBody] OtpRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
                return BadRequest(new
                {
                    success = false,
                    message = "Phone number is required."
                });

            await _otpService.SendOtpAsync(request.PhoneNumber);

            return Ok(new
            {
                success = true,
                message = "OTP sent successfully."
            });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.MobileNumber))
            {
                return BadRequest(new AuthResponseDto
                {
                    isSuccess = false,
                    isNewUser = false,
                    Message = "Mobile number is required",
                    Token = string.Empty
                });
            }

            if (string.IsNullOrWhiteSpace(dto.Otp))
            {
                return BadRequest(new AuthResponseDto
                {
                    isSuccess = false,
                    isNewUser = false,
                    Message = "OTP is required",
                    Token = string.Empty
                });
            }

            var result = await _otpService.VerifyOtpAsync(dto.MobileNumber, dto.Otp);

            if (!result.isSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }

    public class OtpRequestDto
    {
        public string PhoneNumber { get; set; }
    }
}