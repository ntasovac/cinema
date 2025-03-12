using Cinema.Domain.Entities;
using Cinema.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
