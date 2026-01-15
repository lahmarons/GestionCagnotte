using Cagnotte.Domain.DTOs.Participation;
using Cagnotte.Services;
using Microsoft.AspNetCore.Mvc;

namespace CagnotteParticipativeExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipationController : ControllerBase
    {
        private readonly IParticipationService _participationService;

        public ParticipationController(IParticipationService participationService)
        {
            _participationService = participationService;
        }

        /// <summary>
        /// Récupère toutes les participations
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipationDto>>> GetAll()
        {
            var participations = await _participationService.GetAllAsync();
            return Ok(participations);
        }

        /// <summary>
        /// Récupère une participation par CagnotteId et ParticipantId
        /// </summary>
        [HttpGet("{cagnotteId}/{participantId}")]
        public async Task<ActionResult<ParticipationDto>> GetById(int cagnotteId, int participantId)
        {
            var participation = await _participationService.GetByIdAsync(cagnotteId, participantId);
            
            if (participation == null)
                return NotFound($"Participation pour Cagnotte {cagnotteId} et Participant {participantId} introuvable");

            return Ok(participation);
        }

        /// <summary>
        /// Récupère toutes les participations d'une cagnotte
        /// </summary>
        [HttpGet("cagnotte/{cagnotteId}")]
        public async Task<ActionResult<IEnumerable<ParticipationDto>>> GetByCagnotte(int cagnotteId)
        {
            var participations = await _participationService.GetByCagnotteIdAsync(cagnotteId);
            return Ok(participations);
        }

        /// <summary>
        /// Récupère toutes les participations d'un participant
        /// </summary>
        [HttpGet("participant/{participantId}")]
        public async Task<ActionResult<IEnumerable<ParticipationDto>>> GetByParticipant(int participantId)
        {
            var participations = await _participationService.GetByParticipantIdAsync(participantId);
            return Ok(participations);
        }

        /// <summary>
        /// Crée une nouvelle participation
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ParticipationDto>> Create([FromBody] CreateParticipationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _participationService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), 
                new { cagnotteId = created.CagnotteId, participantId = created.ParticipantId }, 
                created);
        }

        /// <summary>
        /// Supprime une participation
        /// </summary>
        [HttpDelete("{cagnotteId}/{participantId}")]
        public async Task<IActionResult> Delete(int cagnotteId, int participantId)
        {
            var result = await _participationService.DeleteAsync(cagnotteId, participantId);
            
            if (!result)
                return NotFound($"Participation pour Cagnotte {cagnotteId} et Participant {participantId} introuvable");

            return NoContent();
        }
    }
}
