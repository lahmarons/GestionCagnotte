using Cagnotte.Domain.DTOs.Cagnotte;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cagnotte.Services
{
    public interface ICagnotteService
    {
        Task<IEnumerable<CagnotteDto>> GetAllAsync();
        Task<CagnotteDto?> GetByIdAsync(int id);
        Task<CagnotteDto> CreateAsync(CreateCagnotteDto dto);
        Task<CagnotteDto?> UpdateAsync(int id, UpdateCagnotteDto dto);
        Task<bool> DeleteAsync(int id);
    }
}