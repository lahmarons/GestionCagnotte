using CagnotteEntity = global::Cagnotte.Domain.Entites.Cagnotte;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cagnotte.Data.Repositories
{
    public interface ICagnotteRepository
    {
        Task<IEnumerable<CagnotteEntity>> GetAllAsync();
        Task<CagnotteEntity?> GetByIdAsync(int id);
        Task AddAsync(CagnotteEntity entity);
        Task<CagnotteEntity?> UpdateAsync(int id, CagnotteEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
