using AgriGrader.Application.Interfaces;
using AgriGrader.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgriGrader.Core.Entities;

namespace AgriGrader.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCommodityController : ControllerBase
    {
        private readonly ISubCommodityService _service;

        public SubCommodityController(ISubCommodityService service)
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
        public async Task<IActionResult> Create(SubCommodity subCommodity)
        {
            await _service.AddAsync(subCommodity);
            return Ok();
        }
    }
}
