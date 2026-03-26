
using AgriGrader.Application.Interfaces;
using AgriGrader.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AgriGrader.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _service;

        public BuyerController(IBuyerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {

            return Ok(await _service.GetAllBuyersAsync());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var buyer = await _service.GetBuyerByIdAsync(id);
            return buyer != null ? Ok(buyer) : NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BuyerDto dto)
        {
            await _service.AddBuyerAsync(dto);
            return Ok("Buyer Added");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BuyerDto dto)
        {
            await _service.UpdateBuyerAsync(dto);
            return Ok("Buyer updated");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteBuyerAsync(id);
            return Ok("Buyer deleted");
            
        }
    }
}
