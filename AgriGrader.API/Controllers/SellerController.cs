using AgriGrader.Application.Interfaces;
using AgriGrader.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AgriGrader.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSellers()
        {
            var sellers = await _sellerService.GetAllSellersAsync();
            return Ok(sellers);
        }

        [HttpPost]
        public async Task<IActionResult> AddSeller([FromBody] SellerDto sellerDto)
        {
            await _sellerService.AddSellerAsync(sellerDto);
            return CreatedAtAction(nameof(GetAllSellers), new { name = sellerDto.Name }, sellerDto);
        }
    }
}
