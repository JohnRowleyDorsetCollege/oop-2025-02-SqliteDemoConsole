using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDemoConsole
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            Console.WriteLine("Student added successfully");    
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }
    }
}
