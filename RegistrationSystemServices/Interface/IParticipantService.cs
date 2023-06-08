using EventAppDataLayer.Dto;
using EventAppDataLayer.Entity;

namespace EventAppServices.Interface
{
    public interface IParticipantService
    {
        IEnumerable<ParticipantDto> getParticipants();
        public Guid addParticipant(ParticipantDto dto);
        public void removeParticipant(Guid id);
        public void updateParticipant(ParticipantDto dto);
        public ParticipantDto getParticipantById(Guid id);
    }
}
