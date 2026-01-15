namespace CagnotteParticipative.UI.Models;

public class ContributionDto
{
    public int Id { get; set; }
    public int CagnotteId { get; set; }
    public string NomContributeur { get; set; } = string.Empty;
    public decimal Montant { get; set; }
    public DateTime DateContribution { get; set; }
    public string? Message { get; set; }
}
