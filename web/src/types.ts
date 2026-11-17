export type TaskPriority = "Low" | "Medium" | "High";

export interface TaskItem {
  id: number;
  title: string;
  priority: TaskPriority;
  isDone: boolean;
  createdAt: string;
}

export interface NewTask {
  title: string;
  priority: TaskPriority;
}
