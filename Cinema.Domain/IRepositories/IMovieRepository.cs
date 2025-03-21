using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.IRepositories
{
    public interface IMovieRepository
    {
        Task<Movie> AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task<Movie> GetByIdAsync(int id);
    }
}
