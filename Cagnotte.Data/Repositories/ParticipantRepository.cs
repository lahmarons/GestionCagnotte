using CagnotteEntity = global::Cagnotte.Domain.Entites.Cagnotte;
using Cagnotte.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cagnotte.Data.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly AppDbContext _context;

        public ParticipantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Participant>> GetAllAsync()
        {
            return await _context.Participants
                .Include(p => p.Participations)
                .ToListAsync();
        }

        public async Task<Participant?> GetByIdAsync(int id)
        {
            return await _context.Participants
                .Include(p => p.Participations)
                    .ThenInclude(pa => pa.Cagnotte)
                .FirstOrDefaultAsync(p => p.ParticipantId == id);
        }

        public async Task AddAsync(Participant entity)
        {
            await _context.Participants.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Participant?> UpdateAsync(int id, Participant entity)
        {
            var existing = await _context.Participants
                .FirstOrDefaultAsync(p => p.ParticipantId == id);

            if (existing == null)
                return null;

            existing.Nom = entity.Nom;
            existing.Prenom = entity.Prenom;
            existing.MailParticipant = entity.MailParticipant;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var participant = await _context.Participants
                .FirstOrDefaultAsync(p => p.ParticipantId == id);

            if (participant == null)
                return false;

            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
