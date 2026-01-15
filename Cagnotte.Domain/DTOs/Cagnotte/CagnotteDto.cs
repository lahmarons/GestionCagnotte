using Cagnotte.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cagnotte.Domain.DTOs.Cagnotte
{
    public class CagnotteDto
    {
        public int CagnotteId { get; set; }
        public required string Titre { get; set; }
        public required string Description { get; set; }

        public decimal MontantCible { get; set; }
        public DateTime DateFin { get; set; }
        public TypeCagnotte Type { get; set; }

        public decimal MontantCollecte { get; set; }
        public decimal PourcentageAtteint { get; set; }
        public int JoursRestants { get; set; }
        public int NombreParticipants { get; set; }

        public int EntrepriseId { get; set; }
        public required string EntrepriseRaisonSociale { get; set; }
    }

}
