using AutoMapper;
using Cagnotte.Data.Repositories;
using Cagnotte.Domain.DTOs.Participation;
using Cagnotte.Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cagnotte.Services
{
    public class ParticipationService : IParticipationService
    {
        private readonly IParticipationRepository _repo;
        private readonly ICagnotteRepository _cagnotteRepo;
        private readonly IParticipantRepository _participantRepo;
        private readonly IMapper _mapper;

        public ParticipationService(
            IParticipationRepository repo, 
            ICagnotteRepository cagnotteRepo,
            IParticipantRepository participantRepo,
            IMapper mapper)
        {
            _repo = repo;
            _cagnotteRepo = cagnotteRepo;
            _participantRepo = participantRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParticipationDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ParticipationDto>>(list);
        }

        public async Task<ParticipationDto?> GetByIdAsync(int cagnotteId, int participantId)
        {
            var entity = await _repo.GetByIdAsync(cagnotteId, participantId);
            return _mapper.Map<ParticipationDto>(entity);
        }

        public async Task<ParticipationDto> CreateAsync(CreateParticipationDto dto)
        {
            // ?? VALIDATION : Vérifier que la cagnotte existe
            var cagnotte = await _cagnotteRepo.GetByIdAsync(dto.CagnotteId);
            if (cagnotte == null)
            {
                throw new InvalidOperationException($"La cagnotte avec l'ID {dto.CagnotteId} n'existe pas. Veuillez d'abord créer la cagnotte.");
            }

            // ?? VALIDATION : Vérifier que le participant existe  
            var participant = await _participantRepo.GetByIdAsync(dto.ParticipantId);
            if (participant == null)
            {
                throw new InvalidOperationException($"Le participant avec l'ID {dto.ParticipantId} n'existe pas. Veuillez d'abord créer le participant.");
            }

            // ?? VALIDATION : Vérifier que la participation n'existe pas déjà
            var existingParticipation = await _repo.GetByIdAsync(dto.CagnotteId, dto.ParticipantId);
            if (existingParticipation != null)
            {
                throw new InvalidOperationException($"Une participation existe déjà pour la cagnotte {dto.CagnotteId} et le participant {dto.ParticipantId}. Utilisez la mise à jour instead.");
            }

            // ?? VALIDATION : Vérifier que le montant est positif
            if (dto.Montant <= 0)
            {
                throw new InvalidOperationException("Le montant de la participation doit être supérieur à 0.");
            }

            // ? Toutes les validations sont OK, créer la participation
            var entity = _mapper.Map<Participation>(dto);
            await _repo.AddAsync(entity);

            return _mapper.Map<ParticipationDto>(entity);
        }

        public async Task<bool> DeleteAsync(int cagnotteId, int participantId)
        {
            return await _repo.DeleteAsync(cagnotteId, participantId);
        }

        public async Task<IEnumerable<ParticipationDto>> GetByCagnotteIdAsync(int cagnotteId)
        {
            var list = await _repo.GetByCagnotteIdAsync(cagnotteId);
            return _mapper.Map<IEnumerable<ParticipationDto>>(list);
        }

        public async Task<IEnumerable<ParticipationDto>> GetByParticipantIdAsync(int participantId)
        {
            var list = await _repo.GetByParticipantIdAsync(participantId);
            return _mapper.Map<IEnumerable<ParticipationDto>>(list);
        }
    }
}
