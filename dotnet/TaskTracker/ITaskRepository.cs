namespace SampleTasks;

public interface ITaskRepository
{
    TaskItem Add(string title, TaskPriority priority);
    TaskItem? FindById(int id);
    IReadOnlyList<TaskItem> GetAll();
}
