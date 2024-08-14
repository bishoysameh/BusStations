using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.BusService;

namespace WebApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetBusById(int id)
        //{
        //    var bus = await _busService.GetBusByIdAsync(id);
        //    if (bus == null)
        //        return NotFound();
        //    return Ok(bus);
        //  }

        [HttpPost]
        public async Task<IActionResult> AddBus([FromBody] CreateBusDto createBusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var busId = await _busService.AddBusRecordAsync(createBusDto);
            return Ok(new { Id = busId });
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> EditBus(int id, [FromBody] EditBusDto editBusDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var result = await _busService.EditBusRecordAsync(id, editBusDto);
        //    if (!result)
        //        return NotFound();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBus(int id)
        //{
        //    var result = await _busService.DeleteBusRecordAsync(id);
        //    if (!result)
        //        return NotFound();

        //    return NoContent();
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetBuses([FromQuery] BusFilterDto filterDto)
        //{
        //    var buses = await _busService.GetBusesListAsync(filterDto);
        //    return Ok(buses);
        //}

        [HttpPost("filter")]
        public async Task<IActionResult> GetFilteredBuses([FromBody] BusFilterDto filterDto)
        {

            if (filterDto == null)
                {
                    return BadRequest("Filter criteria are missing.");
                }

            var buses = await _busService.GetBusesAsync(filterDto);
            return Ok(buses);
        }

        //[HttpPost("import-excel")]
        //public async Task<IActionResult> ImportExcelData([FromBody] IEnumerable<CreateBusDto> busDtos)
        //{
        //    var result = await _busService.SaveExcelDataAsync(busDtos);
        //    return result ? Ok() : StatusCode(500, "Failed to import data");
        //}
    }
}

