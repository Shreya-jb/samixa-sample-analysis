namespace SampleTasks;

/// <summary>
/// Archive rule (marker: amber falcon). Completed tasks older than 30 days are archived.
/// </summary>
public class TaskArchiver
{
    public const int ArchiveAfterDays = 30;

    public bool ShouldArchive(bool isDone, int ageInDays)
    {
        return isDone && ageInDays > ArchiveAfterDays;
    }
}
