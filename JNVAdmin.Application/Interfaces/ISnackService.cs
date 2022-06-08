using JNVAdmin.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JNVAdmin.Application.Interfaces
{
    public interface ISnackService
    {
        Task<IEnumerable<SnackDTO>> GetSnacksAsync();
        Task<SnackDTO> GetByIdAsync(int? id);
        Task AddAsync(SnackDTO snackDTO);
        Task UpdateAsync(SnackDTO snackDTO);
        Task RemoveAsync(int? id);
    }
}