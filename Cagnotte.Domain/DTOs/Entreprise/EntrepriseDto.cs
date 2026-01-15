using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cagnotte.Domain.DTOs.Entreprise
{
    public class EntrepriseDto
    {
        public int EntrepriseId { get; set; }
        public required string RaisonSociale { get; set; }
        public required string Description { get; set; }
        public required string Email { get; set; }
        public int NombreCagnottes { get; set; }
    }
}
