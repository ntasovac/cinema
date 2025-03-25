using Cinema.Application.DTOs;
using Cinema.Application.IServices;
using Cinema.Domain.Entities;
using Cinema.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.Services
{
    public class MovieService : IMovieService
    {
        public readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> CreateMovieAsync(MovieDTO movieDTO)
        {
            var movie = new Movie
            {
                Director = movieDTO.Director,
                Duration = movieDTO.Duration,
                Genre = movieDTO.Genre,
                Description = movieDTO.Description,
                Name = movieDTO.Name,
                PosterImageUrl = movieDTO.PosterImageUrl,
                ReleaseDate = movieDTO.ReleaseDate
            };

            await _movieRepository.AddMovieAsync(movie);
            return movie;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            return await _movieRepository.DeleteMovieAsync(id);
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }

        public async Task<bool> UpdateMovieAsync(int id, MovieDTO updatedMovie)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if(movie  == null)
            {
                return false;
            }
            movie.Director = updatedMovie.Director;
            movie.Duration = updatedMovie.Duration;
            movie.Description = updatedMovie.Description;
            movie.Genre = updatedMovie.Genre;
            movie.Name = updatedMovie.Name;
            movie.PosterImageUrl = updatedMovie.PosterImageUrl;
            movie.ReleaseDate = updatedMovie.ReleaseDate;

            await _movieRepository.UpdateMovieAsync(movie);
            return true;
        }
    }
}
