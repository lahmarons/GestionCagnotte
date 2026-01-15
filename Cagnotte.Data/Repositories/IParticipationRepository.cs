using Cagnotte.Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cagnotte.Data.Repositories
{
    public interface IParticipationRepository
    {
        Task<IEnumerable<Participation>> GetAllAsync();
        Task<Participation?> GetByIdAsync(int cagnotteId, int participantId);
        Task AddAsync(Participation entity);
        Task<bool> DeleteAsync(int cagnotteId, int participantId);
        Task<IEnumerable<Participation>> GetByCagnotteIdAsync(int cagnotteId);
        Task<IEnumerable<Participation>> GetByParticipantIdAsync(int participantId);
    }
}
