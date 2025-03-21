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
            Movie movie = new Movie();
            movie.Director = movieDTO.Director;
            movie.Duration = movieDTO.Duration;
            movie.Description = movieDTO.Description;
            movie.Genre = movieDTO.Genre;
            movie.Name = movieDTO.Name;
            movie.PosterImageUrl = movieDTO.PosterImageUrl;
            movie.ReleaseDate = movieDTO.ReleaseDate;   

            await _movieRepository.AddMovieAsync(movie);
            return movie;

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
