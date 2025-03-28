using Cinema.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Cinema.Application.IServices;
using Cinema.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HallController : Controller
    {
        private readonly IHallService _hallService;
        public HallController(IHallService hallService)
        {
            _hallService = hallService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var halls = await _hallService.GetAllAsync();
            if (halls == null)
                return NotFound("There are no halls currently.");

            return Ok(halls);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<Hall>> Create([FromBody] HallDTO newHall)
        {
            var result = await _hallService.CreateAsync(newHall);
            if (result == null)
                return BadRequest("Invalid hall data");

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Hall>> Update(int id, [FromBody] HallDTO updatedHall)
        {
            var result = await _hallService.UpdateAsync(id, updatedHall);
            if (!result)
                return NotFound("Hall not found");

            return Ok(result); ;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _hallService.DeleteAsync(id);
            if(!result)
                return NotFound("Hall not found");
            return Ok(result);

        }
    }
}
