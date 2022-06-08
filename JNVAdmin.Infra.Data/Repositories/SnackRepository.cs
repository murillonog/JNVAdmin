using JNVAdmin.Domain.Entities;
using JNVAdmin.Domain.Interfaces;
using JNVAdmin.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JNVAdmin.Infra.Data.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private ApplicationDbContext _context;

        public SnackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Snack> CreateAsync(Snack snack)
        {
            _context.Add(snack);
            await _context.SaveChangesAsync();
            return snack;
        }

        public async Task<Snack> GetByIdAsync(int? id)
        {
            return await _context.Snacks.FindAsync(id);
        }

        public async Task<IEnumerable<Snack>> GetSnacksAsync()
        {
            return await _context.Snacks.ToListAsync();
        }

        public async Task<Snack> RemoveAsync(Snack snack)
        {
            _context.Remove(snack);
            await _context.SaveChangesAsync();
            return snack;
        }

        public async Task<Snack> UpdateAsync(Snack snack)
        {
            _context.Update(snack);
            await _context.SaveChangesAsync();
            return snack;
        }
    }
}