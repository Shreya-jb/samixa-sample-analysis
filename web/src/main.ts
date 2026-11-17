import { completeTask, createTask, fetchTasks } from "./taskApi";
import { renderTaskList } from "./taskList";

async function refresh(container: HTMLElement): Promise<void> {
  const tasks = await fetchTasks();
  renderTaskList(container, tasks, async (id) => {
    await completeTask(id);
    await refresh(container);
  });
}

export async function start(): Promise<void> {
  const container = document.getElementById("tasks");
  const form = document.getElementById("new-task") as HTMLFormElement | null;
  if (!container || !form) {
    return;
  }

  form.addEventListener("submit", async (event) => {
    event.preventDefault();
    const title = new FormData(form).get("title")?.toString().trim() ?? "";
    if (!title) {
      return;
    }
    await createTask({ title, priority: "Medium" });
    form.reset();
    await refresh(container);
  });

  await refresh(container);
}

void start();
