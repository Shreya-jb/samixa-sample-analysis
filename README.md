# Samixa Sample — Task Tracker

A tiny, multi-language sample project used to exercise Samixa code analysis.
It is deliberately small, but the files reference each other so the code graph
has real classes, functions, imports and calls to discover.

| Folder | Language | What it does |
|---|---|---|
| `dotnet/TaskTracker/` | C# | Domain model (`TaskItem`), repository interface + in-memory implementation, `TaskService`, console `Program` |
| `webforms/` | ASPX + C# | `Tasks.aspx` page whose code-behind uses `TaskService` |
| `web/src/` | TypeScript | Typed API client (`taskApi.ts`) and a list renderer (`taskList.ts`) wired up in `main.ts` |
| `scripts/` | Python | `report.py` reads `sample_tasks.json` via `models.py` and prints a summary |

## Flow

```
Tasks.aspx ──► Tasks.aspx.cs ──► TaskService ──► ITaskRepository ──► InMemoryTaskRepository
Program.cs ───────────────────► TaskService
main.ts ──► taskApi.ts (fetch /api/tasks) ──► types.ts
        └─► taskList.ts ──► types.ts
report.py ──► models.py ──► sample_tasks.json
```

## Run

```bash
dotnet run --project dotnet/TaskTracker
python scripts/report.py scripts/sample_tasks.json
cd web && npm install && npx tsc --noEmit
```
