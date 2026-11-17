import type { NewTask, TaskItem } from "./types";

const BASE_URL = "/api/tasks";

async function request<T>(url: string, init?: RequestInit): Promise<T> {
  const response = await fetch(url, {
    headers: { "Content-Type": "application/json" },
    ...init,
  });
  if (!response.ok) {
    throw new Error(`Request failed: ${response.status}`);
  }
  return (await response.json()) as T;
}

export function fetchTasks(): Promise<TaskItem[]> {
  return request<TaskItem[]>(BASE_URL);
}

export function createTask(task: NewTask): Promise<TaskItem> {
  return request<TaskItem>(BASE_URL, {
    method: "POST",
    body: JSON.stringify(task),
  });
}

export function completeTask(id: number): Promise<TaskItem> {
  return request<TaskItem>(`${BASE_URL}/${id}/complete`, { method: "POST" });
}
