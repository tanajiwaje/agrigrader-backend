using AgriGrader.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace AgriGrader.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OtpController : ControllerBase
    {
        private readonly IFirebaseOtpService _firebaseOtpService;

        public OtpController(IFirebaseOtpService firebaseOtpService)
        {
            _firebaseOtpService = firebaseOtpService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendOtp([FromBody] OtpRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.PhoneNumber))
                return BadRequest("Phone number is required.");

            await _firebaseOtpService.SendOtpToFirebaseAsync(request.PhoneNumber);
            return Ok("OTP sent to Firebase.");
        }
    }

    public class OtpRequestDto
    {
        public string PhoneNumber { get; set; }
    }
}