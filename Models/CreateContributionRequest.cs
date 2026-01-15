namespace CagnotteParticipative.UI.Models;

public class CreateContributionRequest
{
    public string NomContributeur { get; set; } = string.Empty;
    public decimal Montant { get; set; }
    public string? Message { get; set; }
}