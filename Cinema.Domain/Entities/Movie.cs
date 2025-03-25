using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public List<Actor> Actors { get; set; }
    public string Director { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string PosterImageUrl { get; set; }

}
