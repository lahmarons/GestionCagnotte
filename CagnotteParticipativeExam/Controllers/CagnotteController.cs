using Cagnotte.Domain.DTOs.Cagnotte;
using Cagnotte.Services;
using Microsoft.AspNetCore.Mvc;

namespace CagnotteParticipativeExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CagnotteController : ControllerBase
    {
        private readonly ICagnotteService _cagnotteService;

        public CagnotteController(ICagnotteService cagnotteService)
        {
            _cagnotteService = cagnotteService;
        }

        /// <summary>
        /// Récupère toutes les cagnottes
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CagnotteDto>>> GetAll()
        {
            var cagnottes = await _cagnotteService.GetAllAsync();
            return Ok(cagnottes);
        }

        /// <summary>
        /// Récupère une cagnotte par son ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CagnotteDto>> GetById(int id)
        {
            var cagnotte = await _cagnotteService.GetByIdAsync(id);
            
            if (cagnotte == null)
                return NotFound($"Cagnotte avec l'ID {id} introuvable");

            return Ok(cagnotte);
        }

        /// <summary>
        /// Crée une nouvelle cagnotte
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CagnotteDto>> Create([FromBody] CreateCagnotteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _cagnotteService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.CagnotteId }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Met à jour une cagnotte existante
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<CagnotteDto>> Update(int id, [FromBody] UpdateCagnotteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _cagnotteService.UpdateAsync(id, dto);
            
            if (updated == null)
                return NotFound($"Cagnotte avec l'ID {id} introuvable");

            return Ok(updated);
        }

        /// <summary>
        /// Supprime une cagnotte
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cagnotteService.DeleteAsync(id);
            
            if (!result)
                return NotFound($"Cagnotte avec l'ID {id} introuvable");

            return NoContent();
        }
    }
}
