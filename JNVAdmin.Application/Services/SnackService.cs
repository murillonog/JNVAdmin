using AutoMapper;
using JNVAdmin.Application.Dtos;
using JNVAdmin.Application.Interfaces;
using JNVAdmin.Domain.Entities;
using JNVAdmin.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JNVAdmin.Application.Services
{
    public class SnackService : ISnackService
    {
        private readonly ISnackRepository _snackRepository;
        private readonly IMapper _mapper;

        public SnackService(ISnackRepository snackRepository, IMapper mapper)
        {
            _snackRepository = snackRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(SnackDTO snackDTO)
        {
            var entity = _mapper.Map<Snack>(snackDTO);
            await _snackRepository.CreateAsync(entity);
        }

        public async Task<SnackDTO> GetByIdAsync(int? id)
        {
            var entity = await _snackRepository.GetByIdAsync(id);
            return _mapper.Map<SnackDTO>(entity);
        }

        public async Task<IEnumerable<SnackDTO>> GetSnacksAsync()
        {
            var list = await _snackRepository.GetSnacksAsync();
            return _mapper.Map<IEnumerable<SnackDTO>>(list);
        }

        public async Task RemoveAsync(int? id)
        {
            var entity = _snackRepository.GetByIdAsync(id).Result;
            await _snackRepository.RemoveAsync(entity);
        }

        public async Task UpdateAsync(SnackDTO snackDTO)
        {
            var entity = _mapper.Map<Snack>(snackDTO);
            await _snackRepository.UpdateAsync(entity);
        }
    }
}