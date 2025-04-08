using Cinema.Application.DTOs;
using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.IServices
{
    public interface IHallService
    {
        public Task<List<Hall>> GetAllAsync();
        public Task<Hall> CreateAsync(HallDTO hallDTO);
        public Task<bool> UpdateAsync(int id, HallDTO hallDTO);
        public Task<bool> DeleteAsync(int id);
    }
}
