using Cagnotte.Domain.DTOs.Participant;
using Cagnotte.Services;
using Microsoft.AspNetCore.Mvc;

namespace CagnotteParticipativeExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        /// <summary>
        /// Récupère tous les participants
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantDto>>> GetAll()
        {
            var participants = await _participantService.GetAllAsync();
            return Ok(participants);
        }

        /// <summary>
        /// Récupère un participant par son ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipantDto>> GetById(int id)
        {
            var participant = await _participantService.GetByIdAsync(id);
            
            if (participant == null)
                return NotFound($"Participant avec l'ID {id} introuvable");

            return Ok(participant);
        }

        /// <summary>
        /// Crée un nouveau participant
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ParticipantDto>> Create([FromBody] CreateParticipantDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _participantService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.ParticipantId }, created);
        }

        /// <summary>
        /// Met à jour un participant existant
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<ParticipantDto>> Update(int id, [FromBody] UpdateParticipantDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _participantService.UpdateAsync(id, dto);
            
            if (updated == null)
                return NotFound($"Participant avec l'ID {id} introuvable");

            return Ok(updated);
        }

        /// <summary>
        /// Supprime un participant
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _participantService.DeleteAsync(id);
            
            if (!result)
                return NotFound($"Participant avec l'ID {id} introuvable");

            return NoContent();
        }
    }
}
