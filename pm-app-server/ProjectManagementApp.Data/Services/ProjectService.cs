using ProjectManagementApp.Data.Models;

namespace ProjectManagementApp.Data.Services
{
    public class ProjectService : BaseService<Project>
    {
        public ProjectService(IRepository<Project> projectRepository) : base(projectRepository)
        {
        }
    }
}
