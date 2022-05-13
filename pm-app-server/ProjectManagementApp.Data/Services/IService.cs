using ProjectManagementApp.Data.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectManagementApp.Data.Services
{
    public interface IService
    {
        Task<IEntity> GetAsync(Guid id);

        Task<IEnumerable<IEntity>> GetAllAsync();

        Task UpdateAsync(IEntity entity);
    }
}
