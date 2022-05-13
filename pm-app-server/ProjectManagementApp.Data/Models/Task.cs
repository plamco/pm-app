namespace ProjectManagementApp.Data.Models
{
    public class Task : IEntity
    {
        public Task(Guid iD, string title, string description, string assignee, 
            string type, string priority, string status, int estimate, DateTime createdAt)
        {
            ID = iD;
            Title = title;
            Description = description;
            Assignee = assignee;
            Type = type;
            Priority = priority;
            Status = status;
            Estimate = estimate;
            CreatedAt = createdAt;
        }

        public Guid ID { get; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Assignee { get; set; }

        public string Type { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public int Estimate { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<History> Histories { get; set; } = new List<History>();
    }
}
