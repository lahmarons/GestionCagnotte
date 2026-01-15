using CagnotteEntity = global::Cagnotte.Domain.Entites.Cagnotte;
using Cagnotte.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cagnotte.Data.Repositories
{
    public class EntrepriseRepository : IEntrepriseRepository
    {
        private readonly AppDbContext _context;

        public EntrepriseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entreprise>> GetAllAsync()
        {
            return await _context.Entreprises
                .Include(e => e.cagnottes)
                .ToListAsync();
        }

        public async Task<Entreprise?> GetByIdAsync(int id)
        {
            return await _context.Entreprises
                .Include(e => e.cagnottes)
                .FirstOrDefaultAsync(e => e.EntrepriseId == id);
        }

        public async Task AddAsync(Entreprise entity)
        {
            await _context.Entreprises.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Entreprise?> UpdateAsync(int id, Entreprise entity)
        {
            var existing = await _context.Entreprises
                .FirstOrDefaultAsync(e => e.EntrepriseId == id);

            if (existing == null)
                return null;

            existing.RaisonSociale = entity.RaisonSociale;
            existing.Description = entity.Description;
            existing.Email = entity.Email;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entreprise = await _context.Entreprises
                .FirstOrDefaultAsync(e => e.EntrepriseId == id);

            if (entreprise == null)
                return false;

            _context.Entreprises.Remove(entreprise);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
