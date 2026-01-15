using Cagnotte.Domain.DTOs.Participant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cagnotte.Services
{
    public interface IParticipantService
    {
        Task<IEnumerable<ParticipantDto>> GetAllAsync();
        Task<ParticipantDto?> GetByIdAsync(int id);
        Task<ParticipantDto> CreateAsync(CreateParticipantDto dto);
        Task<ParticipantDto?> UpdateAsync(int id, UpdateParticipantDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
