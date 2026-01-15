using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cagnotte.Domain.DTOs.Participant
{
    using System.ComponentModel.DataAnnotations;

    public class CreateParticipantDto
    {
        [Required, StringLength(50)]
        public required string Nom { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public required string Prenom { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public required string MailParticipant { get; set; }
    }
}
