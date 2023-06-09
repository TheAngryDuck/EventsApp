using EventAppDataLayer.Dto;
using EventAppServices.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsAppServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {

        private readonly ILogger<ParticipantController> _logger;
        private readonly IParticipantService _participantService;

        public ParticipantController(ILogger<ParticipantController> logger, IParticipantService participantService)
        {
            _logger = logger;
            _participantService = participantService;
        }

        // GET: api/<ParticipantController>
        [HttpGet]
        public IEnumerable<ParticipantDto> Get()
        {
            return _participantService.getParticipants();
        }

        // GET api/<ParticipantController>/5
        [HttpGet("{id}")]
        public ActionResult<ParticipantDto> Get(Guid id)
        {
            if (id != Guid.Empty)
            {
                return Ok(_participantService.getParticipantById(id));
            }
            return BadRequest();
        }

        // POST api/<ParticipantController>
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] ParticipantDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Name) && !string.IsNullOrWhiteSpace(dto.LastName) && !string.IsNullOrWhiteSpace(dto.IdCode))
            {
                return Ok(_participantService.addParticipant(dto));
            }
            return BadRequest(dto);
        }

        // PUT api/<ParticipantController>/5
        [HttpPut]
        public ActionResult Put([FromBody] ParticipantDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Name) && !string.IsNullOrWhiteSpace(dto.LastName) && !string.IsNullOrWhiteSpace(dto.IdCode))
            {
                _participantService.updateParticipant(dto);
                return Ok();
            }
            return BadRequest(dto);
        }

        // DELETE api/<ParticipantController>/5
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                _participantService.removeParticipant(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
