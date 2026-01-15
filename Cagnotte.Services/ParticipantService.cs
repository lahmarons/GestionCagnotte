using AutoMapper;
using Cagnotte.Data.Repositories;
using Cagnotte.Domain.DTOs.Participant;
using Cagnotte.Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cagnotte.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _repo;
        private readonly IMapper _mapper;

        public ParticipantService(IParticipantRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParticipantDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ParticipantDto>>(list);
        }

        public async Task<ParticipantDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<ParticipantDto>(entity);
        }

        public async Task<ParticipantDto> CreateAsync(CreateParticipantDto dto)
        {
            var entity = _mapper.Map<Participant>(dto);
            await _repo.AddAsync(entity);

            return _mapper.Map<ParticipantDto>(entity);
        }

        public async Task<ParticipantDto?> UpdateAsync(int id, UpdateParticipantDto dto)
        {
            var entity = _mapper.Map<Participant>(dto);
            var updated = await _repo.UpdateAsync(id, entity);

            return _mapper.Map<ParticipantDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
