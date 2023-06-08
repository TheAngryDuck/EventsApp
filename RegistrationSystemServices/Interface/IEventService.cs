using EventAppDataLayer.Dto;

namespace EventAppDataLayer.Interface
{
    public interface IEventService
    {
        IEnumerable<EventDto> getEvents();
        public Guid addEvent(EventDto eventOb);
        public void removeEvent(Guid id);
        public void updateEvent(EventDto eventOb);
        public EventDto getEventById(Guid id);

    }
}
