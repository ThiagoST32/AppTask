namespace AppTask.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public DateTime FinalDate { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime Create {  get; set; }

        public DateTime Updated { get; set; }

        public List<SubTaskModel> SubTasks { get; set; } = new List<SubTaskModel>();
        public TaskModel() { }
    }
}
