namespace TaskBoard.source.task;

public class Task
{
    private readonly int _id;
    private readonly string _title;
    private string? _description;
    private Status _status = Status.Open;

    public Task(int id, string title, string? description = null)
    {
        _id = id;
        _title = title;
        if (description != null)
        {
            _description = description;
        }
    }
    
    public int Id => _id;
    
    public string Title => _title;

    public string? Description
    {
        get => _description;
        set => _description = value;
    }
    
    public Status Status
    {
        get => _status;
        set => _status = value;
    }
}