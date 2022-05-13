using ProjectManagementApp.Data.Models;

namespace ProjectManagementApp.Data.Services
{
    public class HistoryService : BaseService<History>
    {
        public HistoryService(IRepository<History> historyRepository) : base(historyRepository)
        {
        }
    }
}
