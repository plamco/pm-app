using ProjectManagementApp.Data.Models;
using Task = System.Threading.Tasks.Task;
using AppTask = ProjectManagementApp.Data.Models.Task;
using Newtonsoft.Json;

namespace ProjectManagementApp.Data.Services
{
    public class TaskService : BaseService<AppTask>
    {
        private readonly IRepository<History> historyRepository;

        public TaskService(IRepository<AppTask> taskRepository, IRepository<History> historyRepository) : base(taskRepository)
        {
            this.historyRepository = historyRepository;
        }

        public async override Task UpdateAsync(IEntity entity)
        {
            var existing = await ServiceRepository.GetAsync(entity.ID);

            if (existing == null)
            {
                throw new ArgumentException("Cannot update task because it doesn't exist! " +
                        JsonConvert.SerializeObject(entity));
            }

            await ServiceRepository.UpdateAsync((AppTask)entity, existing);

            var id = Guid.NewGuid();
            await historyRepository.InsertAsync(new History(id, DateTime.UtcNow, JsonConvert.SerializeObject(existing),
                JsonConvert.SerializeObject(entity)));
        }
    }
}
