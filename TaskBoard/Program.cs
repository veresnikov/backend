using TaskBoard.source.board;
using TaskBoard.source.task;

void Main()
{
    Board board = new Board();
    string? command;
    do
    {
        command = Console.ReadLine();
        switch (command)
        {
            case "add":
                {
                    Console.WriteLine("enter task name");
                    var title = Console.ReadLine();
                    if (title == String.Empty)
                    {
                        Console.WriteLine("Error: task name can not be null");
                        break;
                    }

                    Console.WriteLine("enter description");
                    var description = Console.ReadLine();
                    Console.WriteLine($"Task created with id {board.AddTask(title, description)}");
                    break;
                }
            case "print":
                {
                    Console.WriteLine("enter task id");
                    int id;
                    if (!Int32.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine($"Error: incorrect id");
                        break;
                    }

                    var task = board.GetTaskById(id);
                    if (task == null)
                    {
                        Console.WriteLine($"Task with id {id} not found");
                        break;
                    }

                    Console.WriteLine($"ID: {task.Id}\n" +
                                      $"Title: {task.Title}\n" +
                                      $"Description: {task.Description}\n" +
                                      $"Status: {task.Status}\n");
                    break;
                }
            case "getAll":
                {
                    Console.WriteLine("Enter task status or empty");
                    var filter = Console.ReadLine();
                    if (filter != String.Empty)
                    {
                        Status status;
                        if (!Status.TryParse(filter, out status))
                        {
                            Console.WriteLine($"Error: incorrect status");
                            break;
                        }

                        foreach (var t in board.GetTasks(status))
                        {
                            Console.WriteLine($"ID: {t.Id}\n" +
                                              $"Title: {t.Title}\n" +
                                              $"Description: {t.Description}\n" +
                                              $"Status: {t.Status}\n");
                        }
                    }
                    else
                    {
                        foreach (var t in board.GetTasks())
                        {
                            Console.WriteLine($"ID: {t.Id}\n" +
                                              $"Title: {t.Title}\n" +
                                              $"Description: {t.Description}\n" +
                                              $"Status: {t.Status}\n");
                        }
                    }

                    Console.WriteLine("Done");
                    break;
                }
            case "updateStatus":
                {
                    Console.WriteLine("enter task id");
                    int id;
                    if (!Int32.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine($"Error: incorrect id");
                        break;
                    }
                    var task = board.GetTaskById(id);
                    if (task == null)
                    {
                        Console.WriteLine($"Task with id {id} not found");
                        break;
                    }
                    Console.WriteLine("Enter task status");
                    Status status;
                    if (!Status.TryParse(Console.ReadLine(), out status))
                    {
                        Console.WriteLine($"Error: incorrect status");
                        break;
                    }
                    board.UpdateStatus(id, status);
                    Console.WriteLine("Done");
                    break;
                }
            case "updateDescription":
                {
                    Console.WriteLine("enter task id");
                    int id;
                    if (!Int32.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine($"Error: incorrect id");
                        break;
                    }
                    var task = board.GetTaskById(id);
                    if (task == null)
                    {
                        Console.WriteLine($"Task with id {id} not found");
                        break;
                    }
                    Console.WriteLine("Enter task description");
                    board.UpdateDescription(id, Console.ReadLine());
                    Console.WriteLine("Done");
                    break;
                }
            case "delete":
                {
                    Console.WriteLine("enter task id");
                    int id;
                    if (!Int32.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine($"Error: incorrect id");
                        break;
                    }
                    var task = board.GetTaskById(id);
                    if (task == null)
                    {
                        Console.WriteLine($"Task with id {id} not found");
                        break;
                    }
                    board.DeleteTask(id);
                    Console.WriteLine("Done");
                    break;
                }
            case "exit":
                break;
            default:
                Console.WriteLine("Available command:\n" +
                                  "add - add task into board\n" +
                                  "print - print task\n" +
                                  "getAll - print all task\n" +
                                  "updateStatus - update task status\n" +
                                  "updateDescription - update task description\n" +
                                  "delete - delete task\n" +
                                  "exit\n");
                break;
        }
    } while (command != "exit");
}

Main();
