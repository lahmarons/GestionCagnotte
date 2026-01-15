using Cagnotte.Domain.DTOs.Participation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cagnotte.Services
{
    public interface IParticipationService
    {
        Task<IEnumerable<ParticipationDto>> GetAllAsync();
        Task<ParticipationDto?> GetByIdAsync(int cagnotteId, int participantId);
        Task<ParticipationDto> CreateAsync(CreateParticipationDto dto);
        Task<bool> DeleteAsync(int cagnotteId, int participantId);
        Task<IEnumerable<ParticipationDto>> GetByCagnotteIdAsync(int cagnotteId);
        Task<IEnumerable<ParticipationDto>> GetByParticipantIdAsync(int participantId);
    }
}
