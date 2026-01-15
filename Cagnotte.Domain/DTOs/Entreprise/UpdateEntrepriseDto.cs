using System.ComponentModel.DataAnnotations;

public class UpdateEntrepriseDto
{
    [Required, StringLength(200)]
    public required string RaisonSociale { get; set; }

    [Required, StringLength(500)]
    public required string Description { get; set; }

    [Required, EmailAddress, StringLength(100)]
    public required string Email { get; set; }
}