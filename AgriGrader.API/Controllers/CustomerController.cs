using AgriGrader.Application.DTOs;
using AgriGrader.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgriGrader.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDto dto)
        {
            //
            var result = await _service.AddAsync(dto);
            return Ok(result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await _service.GetAllAsync());
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllPagination(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _service.GetAllPaginationAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
