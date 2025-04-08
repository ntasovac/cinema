using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.IRepositories
{
    public interface IHallRepository
    {
        public Task<List<Hall>> GetAllAsync();
        public Task<Hall> CreateAsync(Hall hall);
        public Task UpdateAsync(Hall hall);
        public Task<bool> DeleteAsync(int id);
        public Task<Hall> GetByIdAsync(int id);
    }
}
