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

            //var repo = new DapperDepartmentRepository(conn);
            //Console.WriteLine("Type a new Department Name");
            //var newDepartment = Console.ReadLine();
            //Console.WriteLine();

            //repo.InsertDepartment(newDepartment);
            //var departments = repo.GetAllDepartments();

            //foreach(var d in departments)
            //{
            //    Console.WriteLine(d.Name);
            //}

            var pRepo = new DapperProductRepository(conn);
            Console.WriteLine("Type a new Product Name");
            var newProductName = Console.ReadLine();
            Console.WriteLine("Type a new Product Price(double)");
            var newProductPrice = double.Parse(Console.ReadLine());
            Console.WriteLine();

            pRepo.CreateProduct(newProductName, newProductPrice, 4);
            var products = pRepo.GetAllProducts();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductID} {p.Name} {p.Price} {p.CategoryID} {p.StockLevel}");
            }

            Console.WriteLine();
            Console.WriteLine("Type the productID to change its name(int)");
            var productID = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the new Name");
            newProductPrice = int.Parse(Console.ReadLine());
            pRepo.UpdateProductName(productID, newProductPrice);
            products = pRepo.GetAllProducts();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductID} {p.Name} {p.Price} {p.CategoryID} {p.StockLevel}");
            }
            Console.WriteLine();
            Console.WriteLine("Type the productID to Delete from table(int)");
            productID = int.Parse(Console.ReadLine());
            pRepo.DeleteProduct(productID);
            products = pRepo.GetAllProducts();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductID} {p.Name} {p.Price} {p.CategoryID} {p.StockLevel}");
            }
        }
    }
}
