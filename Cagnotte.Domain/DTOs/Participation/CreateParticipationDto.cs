using System.ComponentModel.DataAnnotations;

public class CreateParticipationDto
{
    [Required]
    public int CagnotteId { get; set; }

    [Required]
    public int ParticipantId { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Montant { get; set; }
}
