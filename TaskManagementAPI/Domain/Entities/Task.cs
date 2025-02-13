namespace TaskManagement.Domain.Entities
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<SubTask>? SubTasks { get; } = null!;
    }
}