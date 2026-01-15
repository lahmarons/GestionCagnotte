using System;

namespace Cagnotte.Domain.DTOs.Participation
{
    public class ParticipationDto
    {
        public decimal Montant { get; set; }
        public DateTime DateParticipation { get; set; }
        public int ParticipantId { get; set; }
        public required string NomCompletParticipant { get; set; }
        public int CagnotteId { get; set; }
        public required string CagnotteTitre { get; set; }
    }
}