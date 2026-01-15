namespace CagnotteParticipative.UI.Models;

public class CreateCagnotteRequest
{
    public string Titre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal MontantObjectif { get; set; }
    public DateTime DateLimite { get; set; }
    public string Organisateur { get; set; } = string.Empty;
}