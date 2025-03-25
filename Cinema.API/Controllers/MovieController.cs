using Cinema.Application.DTOs;
using Cinema.Application.IServices;
using Cinema.Domain.Entities;
using Cinema.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers;


[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase

{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] MovieDTO newMovie)
    {
        if (newMovie == null)
        {
            return BadRequest("Invalid movie data");
        } 
        var result = await _movieService.CreateMovieAsync(newMovie);
        if(result == null)
        {
            return BadRequest("Adding new movie failed");
        }
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieDTO updatedMovie)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _movieService.UpdateMovieAsync(id, updatedMovie);
        if(!result)
        {
            return NotFound("Movie not found");
        }
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var result = await _movieService.DeleteMovieAsync(id);
        if(!result)
        {
            return NotFound("Movie not found");
        }
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMovies()
    {
        var result = await _movieService.GetMovies();
        if(result.Count() == 0)
        {
            return NotFound("There is no movies currently");
        }
        return Ok(result);
    }
}
