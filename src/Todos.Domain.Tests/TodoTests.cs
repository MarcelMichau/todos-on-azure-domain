using FluentAssertions;
using Xunit;

namespace Todos.Domain.Tests;

public class TodoTests
{
    [Fact]
    public void GivenValidTask_WhenCreatingATodo_ThenNewTodoHasCorrectText()
    {
        var todoText = "Create a test";
        var newTodo = new Todo(todoText);

        newTodo.Text.Should().Be(todoText);
    }
    
    [Fact]
    public void GivenValidTask_WhenCreatingATodo_ThenNewTodoIsInitiallyNotDone()
    {
        var todoText = "Create a test";
        var newTodo = new Todo(todoText);

        newTodo.IsDone.Should().BeFalse();
    }
    
    [Fact]
    public void GivenTaskWithSpacesForPadding_WhenCreatingATodo_ThenNewTodoTextIsTrimmed()
    {
        var todoText = "     Create a test     ";
        var newTodo = new Todo(todoText);

        newTodo.Text.Should().Be("Create a test");
    }
    
    [Fact]
    public void GivenTask_WhenChangingTodoText_ThenTodoTextIsUpdated()
    {
        var newTodo = new Todo("Create a test");

        var updatedText = "Update this todo";
        newTodo.UpdateText(updatedText);

        newTodo.Text.Should().Be(updatedText);
    }
    
    [Fact]
    public void GivenNotDoneTodo_WhenMarkingAsDone_ThenTodoIsDone()
    {
        var todoText = "Create a test";
        var newTodo = new Todo(todoText);
        
        newTodo.MarkAsDone();

        newTodo.IsDone.Should().BeTrue();
    }
    
    [Fact]
    public void GivenDoneTodo_WhenMarkingAsNotDone_ThenTodoIsNotDone()
    {
        var todoText = "Create a test";
        var newTodo = new Todo(todoText);
        newTodo.MarkAsDone();
        
        newTodo.MarkAsNotDone();

        newTodo.IsDone.Should().BeFalse();
    }
    
    [Fact]
    public void GivenNotDoneTodo_WhenTogglingDone_ThenTodoIsDone()
    {
        var todoText = "Create a test";
        var newTodo = new Todo(todoText);
        
        newTodo.ToggleDone();

        newTodo.IsDone.Should().BeTrue();
    }
    
    [Fact]
    public void GivenDoneTodo_WhenTogglingDone_ThenTodoIsNotDone()
    {
        var todoText = "Create a test";
        var newTodo = new Todo(todoText);
        newTodo.MarkAsDone();
        
        newTodo.ToggleDone();

        newTodo.IsDone.Should().BeFalse();
    }
}