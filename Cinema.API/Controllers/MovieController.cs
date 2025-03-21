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

    private static List<Movie> Movies = new List<Movie>
        {
            new Movie { Id = 1, Name = "The Shawshank Redemption", Genre = "Drama", Duration = 142, Director = "Frank Darabont", ReleaseDate = new DateOnly(1994, 9, 22), Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency." },
            new Movie { Id = 2, Name = "The Dark Knight", Genre = "Action", Duration = 152, Director = "Christopher Nolan", ReleaseDate = new DateOnly(2008, 7, 18), Description = "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham." }
        };

    // GET: api/movie
    [HttpGet]
    public ActionResult<List<Movie>> GetMovies()
    {
        return Ok(Movies);
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
}
