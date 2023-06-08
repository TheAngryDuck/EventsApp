using EventAppDataLayer.Entity;
using EventAppDataLayer.Interface;

namespace EventAppDataLayer.Repository
{
    public class ParticipantRepository : GenericRepository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(EventsAppContext context) : base(context) { }
    }
}
