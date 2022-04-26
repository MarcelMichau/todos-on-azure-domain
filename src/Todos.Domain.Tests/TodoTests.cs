using System;
using FluentAssertions;
using Xunit;

namespace Todos.Domain.Tests;

public class TodoTests
{
    [Fact]
    public void GivenValidTask_WhenCreatingATodo_ThenNewTodoHasCorrectText()
    {
        const string todoText = "Create a test";
        var newTodo = new Todo(todoText);

        newTodo.Text.Should().Be(todoText);
    }
    
    [Fact]
    public void GivenValidTask_WhenCreatingATodo_ThenNewTodoIsInitiallyNotDone()
    {
        const string todoText = "Create a test";
        var newTodo = new Todo(todoText);

        newTodo.IsDone.Should().BeFalse();
    }

    [Fact]
    public void GivenValidTask_WhenCreatingATodo_ThenNewTodoIdIsGenerated()
    {
        const string todoText = "Create a test";
        var newTodo = new Todo(todoText);

        newTodo.Id.Should().NotBeEmpty();
        newTodo.Id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void GivenValidTask_WhenCreatingATodo_ThenNewTodoHasCreatedOnDate()
    {
        const string todoText = "Create a test";
        var newTodo = new Todo(todoText);

        newTodo.CreatedOn.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void GivenTaskWithSpacesForPadding_WhenCreatingATodo_ThenNewTodoTextIsTrimmed()
    {
        const string todoText = "     Create a test     ";
        var newTodo = new Todo(todoText);

        newTodo.Text.Should().Be("Create a test");
    }
    
    [Fact]
    public void GivenTask_WhenChangingTodoText_ThenTodoTextIsUpdated()
    {
        var newTodo = new Todo("Create a test");

        const string updatedText = "Update this todo";
        newTodo.UpdateText(updatedText);

        newTodo.Text.Should().Be(updatedText);
    }
    
    [Fact]
    public void GivenNotDoneTodo_WhenMarkingAsDone_ThenTodoIsDone()
    {
        const string todoText = "Create a test";
        var newTodo = new Todo(todoText);
        
        newTodo.MarkAsDone();

        newTodo.IsDone.Should().BeTrue();
    }
    
    [Fact]
    public void GivenDoneTodo_WhenMarkingAsNotDone_ThenTodoIsNotDone()
    {
        const string todoText = "Create a test";
        var newTodo = new Todo(todoText);
        newTodo.MarkAsDone();
        
        newTodo.MarkAsNotDone();

        newTodo.IsDone.Should().BeFalse();
    }
    
    [Fact]
    public void GivenNotDoneTodo_WhenTogglingDone_ThenTodoIsDone()
    {
        const string todoText = "Create a test";
        var newTodo = new Todo(todoText);
        
        newTodo.ToggleDone();

        newTodo.IsDone.Should().BeTrue();
    }
    
    [Fact]
    public void GivenDoneTodo_WhenTogglingDone_ThenTodoIsNotDone()
    {
        const string todoText = "Create a test";
        var newTodo = new Todo(todoText);
        newTodo.MarkAsDone();
        
        newTodo.ToggleDone();

        newTodo.IsDone.Should().BeFalse();
    }
}