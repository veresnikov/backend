using TaskBoard.source.task;
using Task = TaskBoard.source.task.Task;

namespace TaskBoard.source.board;

public class Board
{
    private readonly List<Task> _taskPool;
    private int _lastId = 0;

    public Board()
    {
        _taskPool = new List<Task>();
    }
    
    public void AddTask(string title, string? description)
    {
        _taskPool.Add(new Task(_lastId++, title, description));
    }

    public Task? GetTaskById(int id)
    {
        return _taskPool.Find(t => t.Id == id);
    }

    public List<Task> GetTasks()
    {
        return _taskPool;
    }
    
    public List<Task> GetTasks(Status status)
    {
        return _taskPool.FindAll(t => t.Status == status);
    }

    public void UpdateStatus(int id, Status status)
    {
        if (!_taskPool.Exists(t => t.Id == id))
        {
            throw new Exception($"Task with id {id} does not exist.");
        }

        int index = _taskPool.FindIndex(t => t.Id == id);
        _taskPool[index].Status = status;
    }

    public void DeleteTask(int id)
    {
        if (!_taskPool.Exists(t => t.Id == id))
        {
            throw new Exception($"Task with id {id} does not exist.");
        }
        int index = _taskPool.FindIndex(t => t.Id == id);
        _taskPool.Remove(_taskPool[index]);
    }
}