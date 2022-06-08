using AutoMapper;
using JNVAdmin.Application.Dtos;
using JNVAdmin.Application.Interfaces;
using JNVAdmin.Domain.Entities;
using JNVAdmin.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JNVAdmin.Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ScheduleDTO scheduleDTO)
        {
            var entity = _mapper.Map<Schedule>(scheduleDTO);
            await _scheduleRepository.CreateAsync(entity);
        }

        public async Task<ScheduleDTO> GetByIdAsync(int? id)
        {
            var entity = await _scheduleRepository.GetByIdAsync(id);
            return _mapper.Map<ScheduleDTO>(entity);
        }

        public async Task<IEnumerable<ScheduleDTO>> GetSchedulesAsync()
        {
            var list = await _scheduleRepository.GetSchedulesAsync();
            return _mapper.Map<IEnumerable<ScheduleDTO>>(list);
        }

        public async Task RemoveAsync(int? id)
        {
            var entity = _scheduleRepository.GetByIdAsync(id).Result;
            await _scheduleRepository.RemoveAsync(entity);
        }

        public async Task UpdateAsync(ScheduleDTO scheduleDTO)
        {
            var entity = _mapper.Map<Schedule>(scheduleDTO);
            await _scheduleRepository.UpdateAsync(entity);
        }
    }
}