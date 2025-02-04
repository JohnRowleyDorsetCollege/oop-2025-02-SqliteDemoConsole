// See https://aka.ms/new-console-template for more information
using SqliteDemoConsole;
using SQLitePCL;

Console.WriteLine("Hello, World!");

SQLitePCL.Batteries_V2.Init();

var repo = new StudentRepository(new AppDbContext());

var student1 = new Student { Name = "John Doe", Age = 25 };
var student2 = new Student { Name = "Jane Doe", Age = 22 };
repo.Add(student1);
repo.Add(student2);

var students = repo.GetAll();
Console.WriteLine("List of Students");
foreach (var student in students)
{
    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");

}

