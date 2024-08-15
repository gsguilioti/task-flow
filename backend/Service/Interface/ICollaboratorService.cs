using TaskFlow.Dto;
using TaskFlow.Model;

namespace backend.Service.Interface
{
    public interface ICollaboratorService
    {
        Collaborator CreateCollaborator(CollaboratorDto dto);
    }
}
