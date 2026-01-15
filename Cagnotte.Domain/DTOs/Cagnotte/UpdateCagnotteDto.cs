using Cagnotte.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cagnotte.Domain.DTOs.Cagnotte
{
    public class UpdateCagnotteDto
    {
        public required string Titre { get; set; }
        public required string Description { get; set; }
        public decimal MontantCible { get; set; }
        public DateTime DateFin { get; set; }
        public TypeCagnotte Type { get; set; }
    }

}
