using ProjectManagementApp.Data.Services;

namespace ProjectManagementApp.Controllers
{
    public class ProjectsController : BaseController
    {
        public ProjectsController(IService service) : base(service)
        {
        }
    }
}
