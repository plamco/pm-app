using ProjectManagementApp.Data.Models;
using ProjectManagementApp.Data.Services;
using Task = System.Threading.Tasks.Task;

namespace ProjectManagementApp.Data.Data
{
    public class ProjectRepository : BaseRepository, IRepository<Project>
    {
        public ProjectRepository(IApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Project>> GetAsync()
        {
            return System.Threading.Tasks.Task.FromResult(Context.Projects.Values.AsEnumerable());
        }

        public Task<Project> GetAsync(Guid id)
        {
            if (Context.Projects.TryGetValue(id, out var project))
            {
                return Task.FromResult(project);
            }

            return Task.FromResult(default(Project));
        }

        public System.Threading.Tasks.Task InsertAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateAsync(Project newEntity, Project existingEntity)
        {
            throw new NotImplementedException();
        }
    }
}
