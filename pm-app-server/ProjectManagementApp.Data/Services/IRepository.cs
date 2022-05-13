using ProjectManagementApp.Data.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectManagementApp.Data.Services
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAsync();

        Task<T> GetAsync(Guid id);

        Task InsertAsync(T entity);


        Task UpdateAsync(T newEntity, T existingEntity);
    }
}
