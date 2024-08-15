using backend.Repository.Interface;
using TaskFlow.Data;
using TaskFlow.Model;

namespace backend.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly DataContext _context;
        public CollaboratorRepository(DataContext context)
        {
            _context = context;
        }

        public Collaborator GetById(int id) => _context.Collaborators.FirstOrDefault(t => t.Id == id);

        public IEnumerable<Collaborator> GetAll() => _context.Collaborators;

        public void Create(Collaborator collaborator)
        {
            collaborator.CreatedAt = DateTime.Now;
            _context.Collaborators.Add(collaborator);
            _context.SaveChanges();
        }

        public void Update(Collaborator collaborator)
        {
            collaborator.UpdatedAt = DateTime.Now;
            _context.Collaborators.Update(collaborator);
            _context.SaveChanges();
        }

        public void Delete(Collaborator collaborator)
        {
            _context.Collaborators.Remove(collaborator);
            _context.SaveChanges();
        }
    }
}
