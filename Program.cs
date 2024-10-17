using _17._10._24.Repository;
using _17._10._24.Models;

namespace _17._10._24
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=TaskBd;Trusted_Connection=True;";
            TaskRepository taskRepository = new TaskRepository(connectionString);

            Task2 newTask = new Task2
            {
                Title = "Learn Dapper",
                Description = "Study how to use Dapper for data access in C#",
                DueDate = DateTime.Now.AddDays(7),
                IsCompleted = false
            };

            int newTaskId = taskRepository.AddTask(newTask);

            Console.WriteLine($"New task added with ID: {newTaskId}");
        }
    }
}
