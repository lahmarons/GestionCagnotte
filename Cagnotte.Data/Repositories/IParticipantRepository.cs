using Cagnotte.Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cagnotte.Data.Repositories
{
    public interface IParticipantRepository
    {
        Task<IEnumerable<Participant>> GetAllAsync();
        Task<Participant?> GetByIdAsync(int id);
        Task AddAsync(Participant entity);
        Task<Participant?> UpdateAsync(int id, Participant entity);
        Task<bool> DeleteAsync(int id);
    }
}
