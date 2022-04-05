using System;
using NUnit.Framework;
using TaskBoard.source.board;
using TaskBoard.source.task;

namespace TestTaskBoard;

[TestFixture]
public class Tests
{
    private Board Board;
    
    [SetUp]
    public void Setup()
    {
        Board = new Board();
    }
    
    [Test, Description("Testing add and remove task on board")]
    public void TestAddAndRemoveTask()
    {
        string title = "Test task";
        int id = Board.AddTask(title);
        var task = Board.GetTaskById(id);
        Assert.AreEqual(Status.Open, task.Status );
        StringAssert.AreEqualIgnoringCase(title, task.Title);
        Assert.Null(task.Description);
        Board.DeleteTask(id);
        Assert.Null(Board.GetTaskById(id));
    }

    [Test, Description("Testing change status task on board")]
    public void TestChangeTaskStatus()
    {
        string title = "Test task";
        int id = Board.AddTask(title);
        var task = Board.GetTaskById(id);
        Assert.AreEqual(Status.Open, task.Status);
        Board.UpdateStatus(id, Status.Backlog);
        Assert.AreEqual(Status.Backlog, task.Status);
        Board.DeleteTask(id);
    }
    
    [Test, Description("Testing change description task on board")]
    public void TestChangeTaskDescription()
    {
        string title = "Test task";
        int id = Board.AddTask(title);
        var task = Board.GetTaskById(id);
        Assert.Null(task.Description);
        Board.UpdateDescription(id, title);
        StringAssert.AreEqualIgnoringCase(title, title);
        Board.DeleteTask(id);
    }
    
    [Test, Description("Testing getting tasks list on board")]
    public void TestTaskList()
    {
        const int size = 10;
        int[] ids = new int[size];
        for (int i = 0; i < size; i++)
        {
            ids[i] = Board.AddTask($"task {i}");
        }

        Assert.AreEqual(size, Board.GetTasks().Count);
        
        for (int i = 0; i < size; i++)
        {
            Board.UpdateStatus(i, Status.Fixed);
        }
        
        Assert.AreEqual(0, Board.GetTasks(Status.Open).Count);
        Assert.AreEqual(size, Board.GetTasks(Status.Fixed).Count);
        for (int i = 0; i < size; i++)
        {
            Board.DeleteTask(i);
        }
    }
    
    [Test, Description("Testing update unavailable task on board")]
    public void TestUpdateUnavailableTask()
    {
        Assert.AreEqual(0, Board.GetTasks().Count);
        Assert.Throws<Exception>(() => Board.DeleteTask(1));
        Assert.Throws<Exception>(() => Board.UpdateDescription(1));
        Assert.Throws<Exception>(() => Board.UpdateStatus(1, Status.Backlog));
    }
}