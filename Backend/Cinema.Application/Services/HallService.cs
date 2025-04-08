using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Application.DTOs;
using Cinema.Application.IServices;
using Cinema.Domain.Entities;
using Cinema.Domain.IRepositories;

namespace Cinema.Application.Services
{
    public class HallService: IHallService
    {
        private readonly IHallRepository _hallRepository;

        public HallService(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
        }

        public Task<List<Hall>> GetAllAsync()
        {
            return _hallRepository.GetAllAsync();
        }

        public async Task<Hall> CreateAsync(HallDTO newHall)
        {
            var hall = new Hall
            {
                Name = newHall.Name,
                TotalSeats = newHall.TotalSeats,
            };
            return await _hallRepository.CreateAsync(hall);
        }

        public async Task<bool> UpdateAsync(int id, HallDTO updatedHall)
        {
            var hall = await  _hallRepository.GetByIdAsync(id);
            if (hall == null)
                return false;

            hall.Number = updatedHall.Number;
            hall.TotalSeats = updatedHall.TotalSeats;
            await _hallRepository.UpdateAsync(hall);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            return await _hallRepository.DeleteAsync(id);
        }
    }
}
