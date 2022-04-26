namespace Todos.Domain;

public class Todo
{
    public Guid Id { get; init; }
    public DateTimeOffset CreatedOn { get; init; }
    public string? Text { get; set; }
    public bool IsDone { get; set; }

    public Todo(string taskText)
    {
        UpdateText(taskText);
        Id = Guid.NewGuid();
        CreatedOn = DateTimeOffset.Now;
        IsDone = false;
    }

    public void UpdateText(string taskText)
    {
        if (string.IsNullOrWhiteSpace(taskText))
            throw new ArgumentException("Task text cannot be empty nor only whitespace", nameof(taskText));

        Text = taskText.Trim();
    }

    public void ToggleDone()
    {
        IsDone = !IsDone;
    }

    public void MarkAsDone()
    {
        IsDone = true;
    }
    
    public void MarkAsNotDone()
    {
        IsDone = false;
    }
}