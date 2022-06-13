using JNVAdmin.Domain.Entities;
using JNVAdmin.Domain.Interfaces;
using JNVAdmin.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JNVAdmin.Infra.Data.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private ApplicationDbContext _context;
        protected DbSet<Snack> DbSet;

        public SnackRepository(ApplicationDbContext context)
        {
            _context = context;
            DbSet = _context.Set<Snack>();
        }

        public async Task<Snack> CreateAsync(Snack snack)
        {
            _context.Add(snack);
            _context.Entry(snack).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return snack;
        }

        public async Task<Snack> GetByIdAsync(Guid? id)
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
            _context.Entry(snack).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return snack;
        }
    }
}