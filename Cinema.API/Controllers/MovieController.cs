using Cinema.Application.DTOs;
using Cinema.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers;


[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
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
    /*
    [HttpPost] 
    public ActionResult<Movie> CreateMovie([FromBody] MovieDTO newMovie)
    {

    }*/
}
