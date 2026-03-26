using AgriGrader.Application.DTOs;
using AgriGrader.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth;

namespace AgriGrader.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IOtpService otpService;
        private readonly IAuthService authService;

        public AuthController(IOtpService otpService, IAuthService authService)
        {
            this.otpService = otpService;
            this.authService = authService;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] string mobileNumber)
        {
            var result = await otpService.SendOtpAsync(mobileNumber);
            return Ok(new
            {
                success = result,
                message = "OTP Send successfully"
            });

        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequestDto dto)
        {
            var result = await authService.VerifyOtpAndAuthenticationAsync(dto);
            return Ok(result);

        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginDto dto)
        {
            var result = await authService.GoogleLoginAsync(dto.token);
            return Ok(result);
        }
    }
}
