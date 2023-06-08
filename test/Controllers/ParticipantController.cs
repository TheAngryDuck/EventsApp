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
        public ParticipantDto Get(Guid id)
        {
            return _participantService.getParticipantById(id);
        }

        // POST api/<ParticipantController>
        [HttpPost]
        public Guid Post([FromBody] ParticipantDto dto)
        {
           return  _participantService.addParticipant(dto);
        }

        // PUT api/<ParticipantController>/5
        [HttpPut]
        public void Put([FromBody] ParticipantDto dto)
        {
            _participantService.updateParticipant(dto);
        }

        // DELETE api/<ParticipantController>/5
        [HttpDelete]
        public void Delete(Guid id)
        {
            _participantService.removeParticipant(id);
        }
    }
}
