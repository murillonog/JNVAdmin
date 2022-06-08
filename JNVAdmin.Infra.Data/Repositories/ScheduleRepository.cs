using JNVAdmin.Domain.Entities;
using JNVAdmin.Domain.Interfaces;
using JNVAdmin.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JNVAdmin.Infra.Data.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private ApplicationDbContext _context;

        public ScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Schedule> CreateAsync(Schedule schedule)
        {
            _context.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule> GetByIdAsync(int? id)
        {
            return await _context.Schedules.FindAsync(id);
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesAsync()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async Task<Schedule> RemoveAsync(Schedule schedule)
        {
            _context.Remove(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule> UpdateAsync(Schedule schedule)
        {
            _context.Update(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }
    }
}