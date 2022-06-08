using JNVAdmin.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JNVAdmin.Domain.Interfaces
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetSchedulesAsync();
        Task<Schedule> GetByIdAsync(int? id);
        Task<Schedule> CreateAsync(Schedule schedule);
        Task<Schedule> UpdateAsync(Schedule schedule);
        Task<Schedule> RemoveAsync(Schedule schedule);
    }
}