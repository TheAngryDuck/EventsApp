using EventAppDataLayer.Entity;
using EventAppDataLayer.Interface;

namespace EventAppDataLayer.Repository
{
    public class ParticipantInEventRepository : GenericRepository<ParticipantInEvent>, IParticipantInEventRepository
    {
        public ParticipantInEventRepository(EventsAppContext context) : base(context) { }

        public IEnumerable<ParticipantInEvent> GetAllRelatedToEventId(Guid id)
        {
            return _context.ParticipansInEvents.Where(p => p.EventId == id).ToList();
        }
    }
}
