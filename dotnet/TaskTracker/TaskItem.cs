namespace SampleTasks;

public enum TaskPriority
{
    Low,
    Medium,
    High
}

public class TaskItem
{
    public int Id { get; init; }
    public string Title { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    public bool IsDone { get; private set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; private set; }

    public void MarkDone()
    {
        if (IsDone)
        {
            return;
        }

        IsDone = true;
        CompletedAt = DateTime.UtcNow;
    }

    public override string ToString() =>
        $"#{Id} [{(IsDone ? "x" : " ")}] {Title} ({Priority})";
}
