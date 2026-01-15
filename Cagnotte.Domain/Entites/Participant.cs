using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cagnotte.Domain.Entites
{
    public class Participant
    {
        public int ParticipantId { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [MaxLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")]
        [Display(Name = "Nom du participant")]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [StringLength(100, MinimumLength = 2,
              ErrorMessage = "Le prénom doit contenir entre 2 et 100 caractères")]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email du participant est obligatoire")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        [StringLength(100, ErrorMessage = "L'email ne peut pas dépasser 100 caractères")]
        [Display(Name = "Email")]
        public string MailParticipant { get; set; } = string.Empty;

        public ICollection<Participation>? Participations { get; set; }

        [NotMapped]
        [Display(Name = "Nom Complet")]
        public string NomComplet => $"{Prenom} {Nom}";

        [NotMapped]
        [Display(Name = "Total Contribué")]
        [DisplayFormat(DataFormatString = "{0:N2} €")]
        public decimal TotalContribue
        {
            get
            {
                if (Participations == null || Participations.Count == 0)
                    return 0;

                decimal total = 0;
                foreach (var participation in Participations)
                {
                    total += participation.Montant;
                }
                return total;
            }
        }

        [NotMapped]
        [Display(Name = "Nombre de Participations")]
        public int NombreParticipations => Participations?.Count ?? 0;
    }
}
