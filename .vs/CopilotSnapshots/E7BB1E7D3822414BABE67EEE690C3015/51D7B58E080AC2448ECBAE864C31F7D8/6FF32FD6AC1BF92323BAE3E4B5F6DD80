using CagnotteEntity = global::Cagnotte.Domain.Entites.Cagnotte;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cagnotte.Data.Repositories
{
    public class CagnotteRepository : ICagnotteRepository
    {
        private readonly AppDbContext _context;

        public CagnotteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CagnotteEntity>> GetAllAsync()
        {
            // ✅ CORRECTION : Charger les participations pour les calculs automatiques
            return await _context.Cagnottes
                .Include(c => c.Participations)  // ← Charge les participations
                .Include(c => c.Entreprise)      // ← Charge aussi l'entreprise (utile pour les DTOs)
                .ToListAsync();
        }

        public async Task<CagnotteEntity?> GetByIdAsync(int id)
        {
            // ✅ CORRECTION : Charger les participations pour les calculs automatiques
            return await _context.Cagnottes
                .Include(c => c.Participations)  // ← Charge les participations
                .Include(c => c.Entreprise)      // ← Charge aussi l'entreprise
                .FirstOrDefaultAsync(c => c.CagnotteId == id);
        }

        public async Task AddAsync(CagnotteEntity entity)
        {
            await _context.Cagnottes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<CagnotteEntity?> UpdateAsync(int id, CagnotteEntity entity)
        {
            var existing = await _context.Cagnottes
                .Include(c => c.Participations)  // ✅ Inclure pour les calculs après mise à jour
                .FirstOrDefaultAsync(c => c.CagnotteId == id);

            if (existing == null)
                return null;

            existing.Titre = entity.Titre;
            existing.Description = entity.Description;
            existing.MontantCible = entity.MontantCible;
            existing.DateFin = entity.DateFin;
            existing.Type = entity.Type;
            existing.EntrepriseId = entity.EntrepriseId;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cagnotte = await _context.Cagnottes
                .FirstOrDefaultAsync(c => c.CagnotteId == id);

            if (cagnotte == null)
                return false;

            _context.Cagnottes.Remove(cagnotte);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
