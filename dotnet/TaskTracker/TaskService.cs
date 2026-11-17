namespace SampleTasks;

public class TaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public TaskItem AddTask(string title, TaskPriority priority = TaskPriority.Medium)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is required.", nameof(title));
        }

        return _repository.Add(title.Trim(), priority);
    }

    public bool CompleteTask(int id)
    {
        var item = _repository.FindById(id);
        if (item is null)
        {
            return false;
        }

        item.MarkDone();
        return true;
    }

    public IReadOnlyList<TaskItem> ListOpenTasks() =>
        _repository.GetAll()
            .Where(t => !t.IsDone)
            .OrderByDescending(t => t.Priority)
            .ToList();

    public IReadOnlyList<TaskItem> ListAllTasks() => _repository.GetAll();
}
