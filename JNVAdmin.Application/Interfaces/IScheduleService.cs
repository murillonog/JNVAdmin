using JNVAdmin.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JNVAdmin.Application.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleDTO>> GetSchedulesAsync();
        Task<ScheduleDTO> GetByIdAsync(int? id);
        Task AddAsync(ScheduleDTO scheduleDTO);
        Task UpdateAsync(ScheduleDTO scheduleDTO);
        Task RemoveAsync(int? id);
    }
}