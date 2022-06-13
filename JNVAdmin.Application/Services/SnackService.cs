using AutoMapper;
using JNVAdmin.Application.Dtos;
using JNVAdmin.Application.Interfaces;
using JNVAdmin.Domain.Entities;
using JNVAdmin.Domain.Interfaces;
using System;
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

        public async Task<SnackDTO> AddAsync(SnackDTO snackDTO)
        {
            var entity = _mapper.Map<Snack>(snackDTO);
            return _mapper.Map<SnackDTO>(await _snackRepository.CreateAsync(entity));
        }

        public async Task<SnackDTO> GetByIdAsync(Guid? id)
        {
            var entity = await _snackRepository.GetByIdAsync(id);
            return _mapper.Map<SnackDTO>(entity);
        }

        public async Task<IEnumerable<SnackDTO>> GetSnacksAsync()
        {
            var list = await _snackRepository.GetSnacksAsync();
            return _mapper.Map<IEnumerable<SnackDTO>>(list);
        }

        public async Task RemoveAsync(Guid? id)
        {
            var entity = _snackRepository.GetByIdAsync(id).Result;
            await _snackRepository.RemoveAsync(entity);
        }

        public async Task UpdateAsync(Guid id, SnackDTO snackDTO)
        {
            var snack = _snackRepository.GetByIdAsync(id).Result;
            if (snack is null)
            {
                throw new ApplicationException($"Snack could not be found.");
            }
            else
            {
                snack.Update(id, snackDTO.Name, snack.CreatedBy, snack.Created, snackDTO.ModifiedBy);
                await _snackRepository.UpdateAsync(snack);
            }
        }
    }
}