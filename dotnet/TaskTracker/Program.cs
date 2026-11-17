using SampleTasks;

var service = new TaskService(new InMemoryTaskRepository());

service.AddTask("Write README", TaskPriority.Low);
var bug = service.AddTask("Fix login bug", TaskPriority.High);
service.AddTask("Review pull request");

service.CompleteTask(bug.Id);

Console.WriteLine("Open tasks:");
foreach (var task in service.ListOpenTasks())
{
    Console.WriteLine($"  {task}");
}
