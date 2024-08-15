using Microsoft.EntityFrameworkCore;

namespace backend.Repository.Interface
{
    public interface ITaskRepository
    {
        TaskFlow.Model.Task GetById(int id);
        IEnumerable<TaskFlow.Model.Task> GetAll();
        IEnumerable<TaskFlow.Model.Task> GetAllByProject(int id);
        void Create(TaskFlow.Model.Task task);
        void Update(TaskFlow.Model.Task task);
        void Delete(TaskFlow.Model.Task task);
    }
}
