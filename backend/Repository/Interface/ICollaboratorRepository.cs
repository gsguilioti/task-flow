using Microsoft.EntityFrameworkCore;
using TaskFlow.Model;

namespace backend.Repository.Interface
{
    public interface ICollaboratorRepository
    {
        public Collaborator GetById(int id);
        public IEnumerable<Collaborator> GetAll();
        public void Create(Collaborator collaborator);
        public void Update(Collaborator collaborator);
        public void Delete(Collaborator collaborator);
    }
}
