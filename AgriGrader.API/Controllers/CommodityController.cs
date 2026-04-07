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

        [HttpGet("pagination")]
        public async Task<IActionResult> GetAllPagination(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _service.GetAllPaginationAsync(pageNumber, pageSize);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCommodityDto dto)
        {
            var result = await _service.AddAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound(new { message = "Commodity Not Found" });
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCommodityDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID Mismatch" });

            var isUpdated = await _service.UpdateAsync(dto);

            if (!isUpdated)
                return NotFound(new { message = "Commodity Not Found" });

            return Ok(new { message = "Commodity Updated Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _service.DeleteAsync(id);
            if (!isDeleted)
                return NotFound(new { message = "Commodity Not Found" });


            return Ok(new { message = "Commodity Deleted Successfully" });
        }
    }
}
