namespace Todos.Domain;

public class Todo
{
    public int Id { get; set; }
    public string? Text { get; private set; }
    public bool IsDone { get; private set; }

    public Todo(string taskText)
    {
        UpdateText(taskText);
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