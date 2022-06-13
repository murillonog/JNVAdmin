using JNVAdmin.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JNVAdmin.Application.Interfaces
{
    public interface ISnackService
    {
        Task<IEnumerable<SnackDTO>> GetSnacksAsync();
        Task<SnackDTO> GetByIdAsync(Guid? id);
        Task<SnackDTO> AddAsync(SnackDTO snackDTO);
        Task UpdateAsync(Guid id, SnackDTO snackDTO);
        Task RemoveAsync(Guid? id);
    }
}