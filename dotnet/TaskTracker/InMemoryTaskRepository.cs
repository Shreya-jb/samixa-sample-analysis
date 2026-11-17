namespace SampleTasks;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _items = new();
    private int _nextId = 1;

    public TaskItem Add(string title, TaskPriority priority)
    {
        var item = new TaskItem
        {
            Id = _nextId++,
            Title = title,
            Priority = priority
        };
        _items.Add(item);
        return item;
    }

    public TaskItem? FindById(int id) => _items.FirstOrDefault(t => t.Id == id);

    public IReadOnlyList<TaskItem> GetAll() => _items.AsReadOnly();
}
