using JNVAdmin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JNVAdmin.Domain.Interfaces
{
    public interface ISnackRepository
    {
        Task<IEnumerable<Snack>> GetSnacksAsync();
        Task<Snack> GetByIdAsync(Guid? id);
        Task<Snack> CreateAsync(Snack snack);
        Task<Snack> UpdateAsync(Snack snack);
        Task<Snack> RemoveAsync(Snack snack);
    }
}