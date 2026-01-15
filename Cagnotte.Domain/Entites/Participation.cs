using CagnotteEntity = global::Cagnotte.Domain.Entites.Cagnotte;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cagnotte.Domain.Entites;  
public class Participation
{
    [Required]
    [Display(Name = "Cagnotte")]
    public int CagnotteId { get; set; }
    
    [Required]
    [Display(Name = "Participant")]
    public int ParticipantId { get; set; }
    
    [Required(ErrorMessage = "Le montant est obligatoire")]
    [Range(0.01, double.MaxValue,
               ErrorMessage = "Le montant doit être un nombre strictement positif")]
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Montant")]
    [DisplayFormat(DataFormatString = "{0:N2} €", ApplyFormatInEditMode = false)]
    public decimal Montant { get; set; }
    
    [Required]
    [Display(Name = "Date de Participation")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime DateParticipation { get; set; } = DateTime.Now;
    
    public CagnotteEntity? Cagnotte { get; set; }
    public Participant? Participant { get; set; }
}
