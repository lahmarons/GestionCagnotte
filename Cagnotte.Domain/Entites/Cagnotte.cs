using Cagnotte.Domain.Entites;
using Cagnotte.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cagnotte.Domain.Entites
{
    public class Cagnotte
    {
        public int CagnotteId { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire")]
        [StringLength(200, ErrorMessage = "Le titre ne peut pas dépasser 200 caractères", MinimumLength = 3)]
        [Display(Name = "Titre de la cagnotte")]
        public string Titre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La description est obligatoire")]
        [StringLength(1000, ErrorMessage = "La description ne peut pas dépasser 1000 caractères", MinimumLength = 10)]
        [Display(Name = "Description de la cagnotte")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Le montant demandé est obligatoire")]
        [Range(1, double.MaxValue, ErrorMessage = "Le montant cible doit être supérieur à 0")]
        [Display(Name = "Montant demandé")]
        public decimal MontantCible { get; set; }

        [Required(ErrorMessage = "La date de fin est obligatoire")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de fin de la cagnotte")]
        public DateTime DateFin { get; set; }

        [Required(ErrorMessage = "Le type de cagnotte est obligatoire")]
        [Display(Name = "Type de Cagnotte")]
        public TypeCagnotte Type { get; set; }

        [Required]
        [Display(Name = "Entreprise")]
        public int EntrepriseId { get; set; }

        public Entreprise? Entreprise { get; set; }

        public ICollection<Participation>? Participations { get; set; }

        [NotMapped]
        public decimal MontantCollecte
        {
            get
            {
                if (Participations == null || Participations.Count == 0)
                    return 0;

                decimal total = 0;
                foreach (var participation in Participations)
                    total += participation.Montant;

                return total;
            }
        }

        [NotMapped]
        public bool EstEnCours => DateTime.Now <= DateFin;

        [NotMapped]
        public decimal PourcentageAtteint
        {
            get
            {
                if (MontantCible == 0)
                    return 0;

                return Math.Min((MontantCollecte / MontantCible) * 100, 100);
            }
        }

        [NotMapped]
        public int JoursRestants
        {
            get
            {
                if (!EstEnCours)
                    return 0;

                return (DateFin - DateTime.Now).Days;
            }
        }

        [NotMapped]
        public int NombreParticipants => Participations?.Count ?? 0;
    }
}
