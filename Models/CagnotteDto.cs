namespace CagnotteParticipative.UI.Models;

public class CagnotteDto
{
    public int Id { get; set; }
    public string Titre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal MontantObjectif { get; set; }
    public decimal MontantCollecte { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateLimite { get; set; }
    public string Organisateur { get; set; } = string.Empty;
    public bool EstActive { get; set; }
}