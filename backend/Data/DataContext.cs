using Microsoft.EntityFrameworkCore;
using TaskFlow.Model;

namespace TaskFlow.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskFlow.Model.Task> Tasks { get; set; }
        public DbSet<TimeTracker> TimeTrackers { get; set; }
    }
}