using backend.Repository;
using TaskFlow.Dto;
using TaskFlow.Model;

namespace backend.Service
{
    public class CollaboratorService
    {
        private readonly UserRepository _userRepository;
        public CollaboratorService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Collaborator CreateCollaborator(CollaboratorDto dto)
        {
            var user = _userRepository.GetByUsername(dto.UserName);
            if(user == null) { throw new ArgumentException("Usuario nao encontrado."); }

            return new Collaborator(dto, user);
        }
    }
}
