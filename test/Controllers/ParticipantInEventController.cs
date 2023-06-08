using EventAppDataLayer.Dto;
using EventAppServices.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsAppServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantInEventController : ControllerBase
    {

        private readonly ILogger<ParticipantInEventController> _logger;
        private readonly IParticipantInEventService _participantInEventService;

        public ParticipantInEventController(ILogger<ParticipantInEventController> logger, IParticipantInEventService participantInEventService)
        {
            _logger = logger;
            _participantInEventService = participantInEventService;
        }

        // GET: api/<ParticipantInEventController>
        [HttpGet]
        public IEnumerable<ParticipantInEventDto> Get()
        {
            return _participantInEventService.getParticipantsInEvents();
        }

        // GET api/<ParticipantInEventController>/5
        [HttpGet("{id}")]
        public ParticipantInEventDto Get(Guid id)
        {
            return _participantInEventService.getParticipantInEventById(id);
        }

        // POST api/<ParticipantInEventController>
        [HttpPost]
        public Guid Post([FromBody] ParticipantInEventDto dto)
        {
           return _participantInEventService.addParticipantInEvent(dto);
        }

        // PUT api/<ParticipantInEventController>/5
        [HttpPut]
        public void Put([FromBody] ParticipantInEventDto dto)
        {
            _participantInEventService.updateParticipantInEvent(dto);
        }

        // DELETE api/<ParticipantInEventController>/5
        [HttpDelete]
        public void Delete(Guid id)
        {
            _participantInEventService.removeParticipantInEvent(id);
        }
    }
}

