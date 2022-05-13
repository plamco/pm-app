namespace ProjectManagementApp.Data.Models
{
    public class Project : IEntity
    {
        public Project(Guid iD, string name, IEnumerable<Task> tasks)
        {
            ID = iD;
            Name = name;
            Tasks = tasks;
        }

        public Guid ID { get; }

        public string Name { get; set; }

        public IEnumerable<Task> Tasks { get; set; }
    }
}
