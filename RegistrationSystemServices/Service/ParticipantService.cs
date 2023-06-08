using EventAppDataLayer.Dto;
using EventAppDataLayer.Interface;
using EventAppDataLayer.Repository;
using EventAppServices.Interface;
using EventAppServices.Mapper;

namespace RegistrationSystemDataLayer.Service
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly ParticipantMapper _participantMapper;


        public ParticipantService(IParticipantRepository participantRepository, ParticipantMapper participantMapper)
        {
            _participantRepository = participantRepository;
            _participantMapper = participantMapper;
        }

        public Guid addParticipant(ParticipantDto dto)
        {
           var entity = _participantRepository.Add(_participantMapper.MapFromDto(dto));
            return entity.Id;

        }

        public IEnumerable<ParticipantDto> getParticipants()
        {
            var result = new List<ParticipantDto>();
            var data = _participantRepository.GetAll();
            foreach (var item in data)
            {
                result.Add(_participantMapper.MapToDto(item));
            }
            return result;
        }

        public void removeParticipant(Guid id)
        {
            _participantRepository.Remove(id);
        }

        public void updateParticipant(ParticipantDto dto)
        {
            _participantRepository.Update(_participantMapper.MapFromDto(dto));
        }
        public ParticipantDto getParticipantById(Guid id)
        {
            return _participantMapper.MapToDto(_participantRepository.GetById(id));
        }
    }
}
