namespace ProjectManagementApp.Data.Models
{
    public class TaskStatus
    {
        public static string ToDo { get; } = "To Do";
        public static string InProgress { get; } = "In Progress";
        public static string ReadyForTest { get; } = "Ready for Test";
        public static string Done { get; } = "Done";

    }
}
