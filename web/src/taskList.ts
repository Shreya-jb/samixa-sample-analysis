import type { TaskItem, TaskPriority } from "./types";

const PRIORITY_ORDER: Record<TaskPriority, number> = { High: 0, Medium: 1, Low: 2 };

export function sortByPriority(tasks: TaskItem[]): TaskItem[] {
  return [...tasks].sort((a, b) => PRIORITY_ORDER[a.priority] - PRIORITY_ORDER[b.priority]);
}

export function renderTaskList(
  container: HTMLElement,
  tasks: TaskItem[],
  onComplete: (id: number) => void,
): void {
  container.innerHTML = "";
  const open = sortByPriority(tasks.filter((t) => !t.isDone));

  if (open.length === 0) {
    container.textContent = "No open tasks.";
    return;
  }

  const list = document.createElement("ul");
  for (const task of open) {
    const item = document.createElement("li");
    item.textContent = `${task.title} (${task.priority}) `;

    const button = document.createElement("button");
    button.textContent = "Done";
    button.addEventListener("click", () => onComplete(task.id));

    item.appendChild(button);
    list.appendChild(item);
  }
  container.appendChild(list);
}
