using EventAppDataLayer.Dto;
using EventAppDataLayer.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly ILogger<EventController> _logger;
        private readonly IEventService _eventService;

        public EventController(ILogger<EventController> logger, IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
        }

        // GET: api/<EventController>
        [HttpGet]
        public List<EventDto> Get()
        {
            return _eventService.getEvents().ToList();
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public ActionResult<EventDto> Get(Guid id)
        {
            if (id != Guid.Empty) { 
                return Ok(_eventService.getEventById(id));
            }
            return BadRequest();
        }

        // POST api/<EventController>
        [HttpPost]
        public ActionResult<Guid> Post([FromBody] EventDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Name) && !string.IsNullOrWhiteSpace(dto.Date))
            {
                return Ok(_eventService.addEvent(dto));
            }
           return BadRequest(dto);
        }

        // PUT api/<EventController>/5
        [HttpPut]
        public ActionResult Put([FromBody] EventDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Name) && !string.IsNullOrWhiteSpace(dto.Date))
            { 
            _eventService.updateEvent(dto);
            return Ok();
            }
            return BadRequest(dto);
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                _eventService.removeEvent(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
