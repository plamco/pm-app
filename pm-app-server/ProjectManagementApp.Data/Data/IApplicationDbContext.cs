using ProjectManagementApp.Data.Models;
using System.Collections.Concurrent;
using Task = ProjectManagementApp.Data.Models.Task;

namespace ProjectManagementApp.Data.Data
{
    public interface IApplicationDbContext
    {
        public ConcurrentDictionary<Guid, Project> Projects { get; set; }

        public ConcurrentDictionary<Guid, Task> Tasks { get; set; }

        public ConcurrentDictionary<Guid, History> History { get; set; }
    }
}
