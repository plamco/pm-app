using Newtonsoft.Json;
using ProjectManagementApp.Data.Models;
using ProjectManagementApp.Data.Services;
using Task = System.Threading.Tasks.Task;

namespace ProjectManagementApp.Data.Data
{
    public class HistoryRepository : BaseRepository, IRepository<History>
    {
        public HistoryRepository(IApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<History>> GetAsync()
        {
            return System.Threading.Tasks.Task.FromResult(Context.History.Values.AsEnumerable());
        }

        public Task<History> GetAsync(Guid id)
        {
            if (Context.History.TryGetValue(id, out var history))
            {
                return Task.FromResult(history);
            }

            return Task.FromResult(default(History));
        }

        public System.Threading.Tasks.Task InsertAsync(History entity)
        {
            var id = Guid.NewGuid();
            if (!Context.History.TryAdd(id, entity))
            {
                throw new InvalidOperationException("Cannot add History tracking for task! " +
                    JsonConvert.SerializeObject(entity));
            }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task UpdateAsync(History newEntity, History existingEntity)
        {
            throw new NotImplementedException();
        }
    }
}
