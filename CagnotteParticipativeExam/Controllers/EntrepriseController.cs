using Cagnotte.Domain.DTOs.Entreprise;
using Cagnotte.Services;
using Microsoft.AspNetCore.Mvc;

namespace CagnotteParticipativeExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrepriseController : ControllerBase
    {
        private readonly IEntrepriseService _entrepriseService;

        public EntrepriseController(IEntrepriseService entrepriseService)
        {
            _entrepriseService = entrepriseService;
        }

        /// <summary>
        /// Récupère toutes les entreprises
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntrepriseDto>>> GetAll()
        {
            var entreprises = await _entrepriseService.GetAllAsync();
            return Ok(entreprises);
        }

        /// <summary>
        /// Récupère une entreprise par son ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<EntrepriseDto>> GetById(int id)
        {
            var entreprise = await _entrepriseService.GetByIdAsync(id);
            
            if (entreprise == null)
                return NotFound($"Entreprise avec l'ID {id} introuvable");

            return Ok(entreprise);
        }

        /// <summary>
        /// Crée une nouvelle entreprise
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<EntrepriseDto>> Create([FromBody] CreateEntrepriseDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _entrepriseService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.EntrepriseId }, created);
        }

        /// <summary>
        /// Supprime une entreprise
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _entrepriseService.DeleteAsync(id);
            
            if (!result)
                return NotFound($"Entreprise avec l'ID {id} introuvable");

            return NoContent();
        }
    }
}
