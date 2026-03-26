using AgriGrader.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgriGrader.Core.Entities;
using AgriGrader.Application.DTOs;
namespace AgriGrader.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityController : ControllerBase
    {
        private readonly ICommodityService _service;

        public CommodityController(ICommodityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCommodityDto dto)
        {
           var result = await _service.AddAsync(dto);
            return Ok(result);
        }
    }
}
