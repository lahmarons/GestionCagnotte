using AutoMapper;
using Cagnotte.Data.Repositories;
using Cagnotte.Domain.DTOs.Cagnotte;
using Cagnotte.Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;
using CagnotteEntity = global::Cagnotte.Domain.Entites.Cagnotte;

namespace Cagnotte.Services
{
    public class CagnotteService : ICagnotteService
    {
        private readonly ICagnotteRepository _repo;
        private readonly IEntrepriseRepository _entrepriseRepo;
        private readonly IMapper _mapper;

        public CagnotteService(ICagnotteRepository repo, IEntrepriseRepository entrepriseRepo, IMapper mapper)
        {
            _repo = repo;
            _entrepriseRepo = entrepriseRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CagnotteDto>> GetAllAsync()
        {
            var cagnottes = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CagnotteDto>>(cagnottes);
        }

        public async Task<CagnotteDto?> GetByIdAsync(int id)
        {
            var cagnotte = await _repo.GetByIdAsync(id);

            if (cagnotte == null)
                return null;

            return _mapper.Map<CagnotteDto>(cagnotte);
        }

        public async Task<CagnotteDto> CreateAsync(CreateCagnotteDto dto)
        {
            // Vérifier que l'entreprise existe
            var entreprise = await _entrepriseRepo.GetByIdAsync(dto.EntrepriseId);
            if (entreprise == null)
            {
                throw new InvalidOperationException($"L'entreprise avec l'ID {dto.EntrepriseId} n'existe pas. Veuillez d'abord créer l'entreprise.");
            }

            var entity = _mapper.Map<CagnotteEntity>(dto);

            await _repo.AddAsync(entity);

            return _mapper.Map<CagnotteDto>(entity);
        }

        public async Task<CagnotteDto?> UpdateAsync(int id, UpdateCagnotteDto dto)
        {
            var entity = _mapper.Map<CagnotteEntity>(dto);
            var updated = await _repo.UpdateAsync(id, entity);

            if (updated == null)
                return null;

            return _mapper.Map<CagnotteDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
