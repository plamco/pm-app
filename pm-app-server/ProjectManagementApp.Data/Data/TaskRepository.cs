using Newtonsoft.Json;
using ProjectManagementApp.Data.Services;
using AppTask = ProjectManagementApp.Data.Models.Task;
using Task = System.Threading.Tasks.Task;

namespace ProjectManagementApp.Data.Data
{
    public class TaskRepository : BaseRepository, IRepository<AppTask>
    {
        public TaskRepository(IApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<AppTask>> GetAsync()
        {
            return System.Threading.Tasks.Task.FromResult(Context.Tasks.Values.AsEnumerable());
        }

        public Task<AppTask> GetAsync(Guid id)
        {
            if (Context.Tasks.TryGetValue(id, out var task))
            {
                return Task.FromResult(task);
            }

            return Task.FromResult(default(AppTask));
        }

        public Task InsertAsync(AppTask entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AppTask newEntity, AppTask existingEntity)
        {
            if (!Context.Tasks.TryUpdate(newEntity.ID, newEntity, existingEntity))
            {
                throw new InvalidOperationException("Cannot update entity! " +
                        JsonConvert.SerializeObject(newEntity));
            }

            return Task.CompletedTask;
        }
    }
}
