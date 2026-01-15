using AutoMapper;
using Cagnotte.Domain.DTOs.Cagnotte;
using Cagnotte.Domain.DTOs.Entreprise;
using Cagnotte.Domain.DTOs.Participant;
using Cagnotte.Domain.DTOs.Participation;
using Cagnotte.Domain.Entites;
using CagnotteEntity = global::Cagnotte.Domain.Entites.Cagnotte;

namespace CagnotteParticipativeExam.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Cagnotte Mappings
            CreateMap<CagnotteEntity, CagnotteDto>()
                .ForMember(dest => dest.EntrepriseRaisonSociale, 
                    opt => opt.MapFrom(src => src.Entreprise != null ? src.Entreprise.RaisonSociale : string.Empty));
            
            CreateMap<CreateCagnotteDto, CagnotteEntity>();
            CreateMap<UpdateCagnotteDto, CagnotteEntity>();

            // Entreprise Mappings
            CreateMap<Entreprise, EntrepriseDto>()
                .ForMember(dest => dest.NombreCagnottes, 
                    opt => opt.MapFrom(src => src.cagnottes != null ? src.cagnottes.Count : 0));
            
            CreateMap<CreateEntrepriseDto, Entreprise>();
            CreateMap<UpdateEntrepriseDto, Entreprise>();

            // Participant Mappings
            CreateMap<Participant, ParticipantDto>()
                .ForMember(dest => dest.HistoriqueParticipations, 
                    opt => opt.MapFrom(src => src.Participations ?? new List<Participation>()));
            
            CreateMap<CreateParticipantDto, Participant>();
            CreateMap<UpdateParticipantDto, Participant>();

            // Participation Mappings
            CreateMap<Participation, ParticipationDto>()
                .ForMember(dest => dest.NomCompletParticipant, 
                    opt => opt.MapFrom(src => src.Participant != null ? src.Participant.NomComplet : string.Empty))
                .ForMember(dest => dest.CagnotteTitre, 
                    opt => opt.MapFrom(src => src.Cagnotte != null ? src.Cagnotte.Titre : string.Empty));
            
            CreateMap<CreateParticipationDto, Participation>()
                .ForMember(dest => dest.DateParticipation, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
