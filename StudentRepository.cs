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

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            Console.WriteLine("Student added successfully");    
        }
        
        public Student? GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(s=> s.Id==id);
        }

        //public void UpdateStudent(Student student)
        //{
        //    _context.Students.Update(student);
        //    _context.SaveChanges();
        //    Console.WriteLine("Student updated successfully");
        //}

        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                Console.WriteLine("Student deleted successfully");
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }

        public void DeleteAllStudents()
        {
            _context.Students.RemoveRange(_context.Students);
            _context.SaveChanges();
            Console.WriteLine("All students deleted successfully");
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }
    }
}
