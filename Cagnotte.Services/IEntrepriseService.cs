using Cagnotte.Domain.DTOs.Entreprise;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cagnotte.Services
{
    public interface IEntrepriseService
    {
        Task<IEnumerable<EntrepriseDto>> GetAllAsync();
        Task<EntrepriseDto> GetByIdAsync(int id);
        Task<EntrepriseDto> AddAsync(CreateEntrepriseDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
