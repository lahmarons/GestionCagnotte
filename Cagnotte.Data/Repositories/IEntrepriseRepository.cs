using Cagnotte.Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cagnotte.Data.Repositories
{
    public interface IEntrepriseRepository
    {
        Task<IEnumerable<Entreprise>> GetAllAsync();
        Task<Entreprise?> GetByIdAsync(int id);
        Task AddAsync(Entreprise entity);
        Task<Entreprise?> UpdateAsync(int id, Entreprise entity);
        Task<bool> DeleteAsync(int id);
    }
}
