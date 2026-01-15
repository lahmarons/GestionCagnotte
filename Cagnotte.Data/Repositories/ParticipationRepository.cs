using CagnotteEntity = global::Cagnotte.Domain.Entites.Cagnotte;
using Cagnotte.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cagnotte.Data.Repositories
{
    public class ParticipationRepository : IParticipationRepository
    {
        private readonly AppDbContext _context;

        public ParticipationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Participation>> GetAllAsync()
        {
            return await _context.Participations
                .Include(p => p.Cagnotte)
                .Include(p => p.Participant)
                .ToListAsync();
        }

        public async Task<Participation?> GetByIdAsync(int cagnotteId, int participantId)
        {
            return await _context.Participations
                .Include(p => p.Cagnotte)
                .Include(p => p.Participant)
                .FirstOrDefaultAsync(p => p.CagnotteId == cagnotteId && p.ParticipantId == participantId);
        }

        public async Task AddAsync(Participation entity)
        {
            await _context.Participations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int cagnotteId, int participantId)
        {
            var participation = await _context.Participations
                .FirstOrDefaultAsync(p => p.CagnotteId == cagnotteId && p.ParticipantId == participantId);

            if (participation == null)
                return false;

            _context.Participations.Remove(participation);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Participation>> GetByCagnotteIdAsync(int cagnotteId)
        {
            return await _context.Participations
                .Include(p => p.Participant)
                .Where(p => p.CagnotteId == cagnotteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Participation>> GetByParticipantIdAsync(int participantId)
        {
            return await _context.Participations
                .Include(p => p.Cagnotte)
                .Where(p => p.ParticipantId == participantId)
                .ToListAsync();
        }
    }
}
