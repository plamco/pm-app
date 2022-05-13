using ProjectManagementApp.Data.Models;
using System.Collections.Concurrent;
using Task = ProjectManagementApp.Data.Models.Task;
using TaskStatus = ProjectManagementApp.Data.Models.TaskStatus;

namespace ProjectManagementApp.Data.Data
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public ConcurrentDictionary<Guid, Project> Projects { get; set; } = new ConcurrentDictionary<Guid, Project>();

        public ConcurrentDictionary<Guid, Task> Tasks { get; set; } = new ConcurrentDictionary<Guid, Task>();

        public ConcurrentDictionary<Guid, History> History { get; set; } = new ConcurrentDictionary<Guid, History>();

        public ApplicationDbContext()
        {
            Tasks = new ConcurrentDictionary<Guid, Task>(new Dictionary<Guid, Task>
            {
                { new Guid("67B3240C-3982-41A9-85ED-87B03B079EF4"), new Task(new Guid("67B3240C-3982-41A9-85ED-87B03B079EF4"), "Project1_Task 1", "Interesting task", 
                    "Ivan Petrov", TaskType.Story, TaskPriority.Low, TaskStatus.ToDo, 2, DateTime.Now) },
                { new Guid("FAD4C97B-3A82-40E6-8ECD-3A8A506689DB"), new Task(new Guid("FAD4C97B-3A82-40E6-8ECD-3A8A506689DB"), "Project1_Task 2", "Obvious task",
                    "Dimitar Dimitrov", TaskType.Story, TaskPriority.Normal, TaskStatus.ReadyForTest, 3, DateTime.Now) },
                { new Guid("C233EE36-757F-400B-AFBE-1792E2B535DE"), new Task(new Guid("C233EE36-757F-400B-AFBE-1792E2B535DE"), "Project1_Task 3", "Clever task",
                    "Petar Kostadinov", TaskType.Bug, TaskPriority.High, TaskStatus.InProgress,4, DateTime.Now) },
                { new Guid("F154602E-7668-426F-A22F-F1F4F49D2D54"), new Task(new Guid("F154602E-7668-426F-A22F-F1F4F49D2D54"), "Project2_Task 1", "Long task",
                    "Ilian Iliev", TaskType.Story, TaskPriority.Critical, TaskStatus.Done, 5, DateTime.Now) },
                { new Guid("8436738F-2BAD-401F-95B1-BBA5C9008894"), new Task(new Guid("8436738F-2BAD-401F-95B1-BBA5C9008894"), "Project2_Task 2", "Short task",
                    "Georgi Georgiev", TaskType.Bug, TaskPriority.Low, TaskStatus.ToDo, 6, DateTime.Now) },
                { new Guid("887FC66F-19E9-4C8C-8C92-EDE58D35BBED"), new Task(new Guid("887FC66F-19E9-4C8C-8C92-EDE58D35BBED"), "Project3_Task 1", "Non-sense task",
                    "Milena Doncheva", TaskType.Story, TaskPriority.Normal, TaskStatus.Done, 7, DateTime.Now) },
            });

            Projects = new ConcurrentDictionary<Guid, Project>(new Dictionary<Guid, Project>
            {
                { new Guid("413607B3-4470-4BA8-9F36-FFF98247E62F"), new Project(new Guid("413607B3-4470-4BA8-9F36-FFF98247E62F"), "Project 1", 
                    Tasks.Values.OrderBy(x => x.Title).Select(x => x).Take(3)) },
                { new Guid("15420E32-CBA4-432E-963A-8F0EBCCAAFE8"), new Project(new Guid("15420E32-CBA4-432E-963A-8F0EBCCAAFE8"), "Project 2",
                    Tasks.Values.OrderBy(x => x.Title).Select(x => x).Skip(3).Take(2)) },
                { new Guid("8D66F983-A0C1-4C3E-A742-ECD263DEDEC5"), new Project(new Guid("8D66F983-A0C1-4C3E-A742-ECD263DEDEC5"), "Project 3",
                    Tasks.Values.OrderBy(x => x.Title).Select(x => x).Skip(5).Take(1)) }
            });
        }
    }
}
