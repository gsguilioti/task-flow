using backend.Repository;
using backend.Repository.Interface;
using backend.Service.Interface;
using TaskFlow.Dto;
using TaskFlow.Model;

namespace backend.Service
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly IUserRepository _userRepository;
        public CollaboratorService(IUserRepository userRepository)
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
