using deze7.Enums;

namespace CompanyTasks.Class
{
    public class WorkTask
    {
        public int TaskNumber { get; set; }
        public string Description { get; set; }
        public string RequiredAction { get; set; }
        public TaskCategory Category { get; set; }

        public WorkTask(int taskNumber, string description, string requiredAction, TaskCategory category)
        {
            TaskNumber = taskNumber;
            Description = description;
            RequiredAction = requiredAction;
            Category = category;
        }

        public void PrintInformation()
        {
            Console.WriteLine($"Номер задачи: {TaskNumber}");
            Console.WriteLine($"Описание: {Description}");
            Console.WriteLine($"Необходимые действия: {RequiredAction}");
            Console.WriteLine($"Категория: {Category}");
        }
    }
}
