namespace ProjectManagementApp.Data.Models
{
    public class History : IEntity
    {
        public History(Guid iD, DateTime date, string current, string previous)
        {
            ID = iD;
            Date = date;
            Current = current;
            Previous = previous;
        }

        public Guid ID { get; }

        public DateTime Date { get; set; }

        public string Current { get; set; }

        public string Previous { get; set; }
    }
}
