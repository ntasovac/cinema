﻿using Cinema.Application.DTOs;
using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.IServices
{
    public interface IMovieService
    {
        Task<Movie> CreateMovieAsync(MovieDTO movie);
        Task<bool> UpdateMovieAsync(int id, MovieDTO movie);
        Task<bool> DeleteMovieAsync(int id);
        Task<List<Movie>> GetMovies();
    }
}
