using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _17._10._24.Models;

namespace _17._10._24.Repository
{
    public class TaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddTask(Task2 task)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string sql = @"
                INSERT INTO Tasks (Title, Description, DueDate, IsCompleted)
                VALUES (@Title, @Description, @DueDate, @IsCompleted);
                SELECT CAST(SCOPE_IDENTITY() as int);";

                int taskId = dbConnection.QuerySingle<int>(sql, new
                {
                    task.Title,
                    task.Description,
                    task.DueDate,
                    task.IsCompleted
                });

                return taskId;
            }
        }
    }
}
