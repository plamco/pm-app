using Newtonsoft.Json;
using ProjectManagementApp.Data.Models;

namespace ProjectManagementApp.Data.Services
{
    public abstract class BaseService<T> : IService where T : IEntity
    {
        protected readonly IRepository<T> ServiceRepository;

        public BaseService(IRepository<T> serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }

        public async virtual Task<IEnumerable<IEntity>> GetAllAsync()
        {
            var entities = await ServiceRepository.GetAsync();

            return entities.Select(e => e as IEntity);
        }

        public async virtual Task<IEntity> GetAsync(Guid id)
        {
            var entities = await ServiceRepository.GetAsync(id);

            return entities;
        }

        public async virtual System.Threading.Tasks.Task UpdateAsync(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
