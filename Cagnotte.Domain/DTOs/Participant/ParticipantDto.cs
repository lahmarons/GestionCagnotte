using Cagnotte.Domain.DTOs.Participation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cagnotte.Domain.DTOs.Participant
{
    public class ParticipantDto
    {
        public int ParticipantId { get; set; }
        public required string NomComplet { get; set; }
        public required string MailParticipant { get; set; }
        public decimal TotalContribue { get; set; }
        public int NombreParticipations { get; set; }
        public required List<ParticipationDto> HistoriqueParticipations { get; set; }
    }
}
