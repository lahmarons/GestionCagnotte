using AutoMapper;
using Cagnotte.Data.Repositories;
using Cagnotte.Domain.DTOs.Entreprise;
using Cagnotte.Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cagnotte.Services
{
    public class EntrepriseService : IEntrepriseService
    {
        private readonly IEntrepriseRepository _repo;
        private readonly IMapper _mapper;

        public EntrepriseService(IEntrepriseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntrepriseDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<EntrepriseDto>>(list);
        }

        public async Task<EntrepriseDto> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<EntrepriseDto>(entity);
        }

        public async Task<EntrepriseDto> AddAsync(CreateEntrepriseDto dto)
        {
            var entity = _mapper.Map<Entreprise>(dto);
            await _repo.AddAsync(entity);

            return _mapper.Map<EntrepriseDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
