using Cinema.Domain.Entities;
using Cinema.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infrastructure.Repositories
{
    public class HallRepository: IHallRepository
    {
        private readonly AppDbContext _context;

        public HallRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hall>> GetAllAsync()
        {
            return await _context.Halls.ToListAsync();
        }

        public async Task<Hall> GetByIdAsync(int id)
        {
            return await _context.Halls.FirstOrDefaultAsync(h => h.Number == id);
        }

        public async Task<Hall> CreateAsync(Hall hall)
        {
            await _context.AddAsync(hall);
            await _context.SaveChangesAsync();
            return hall;
        }

        public async Task UpdateAsync(Hall hall)
        {
            _context.Halls.Update(hall);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hall = await GetByIdAsync(id);
            if (hall == null)
                return false;
            _context.Halls.Remove(hall);
            _context.SaveChanges();
            return true;
        }
    }
}
