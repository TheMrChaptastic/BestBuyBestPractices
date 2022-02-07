using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace BestBuyBestPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperDepartmentRepository(conn);
            Console.WriteLine("Type a new Department Name");
            var newDepartment = Console.ReadLine();
            Console.WriteLine();

            repo.InsertDepartment(newDepartment);
            var departments = repo.GetAllDepartments();

            foreach(var d in departments)
            {
                Console.WriteLine(d.Name);
            }
        }
    }
}
