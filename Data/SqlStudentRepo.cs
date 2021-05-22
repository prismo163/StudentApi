using System;
using System.Collections.Generic;
using System.Linq;
using StudentApi.Models;

namespace StudentApi.Data
{
    public class SqlStudentRepo : IStudentRepo
    {
        private readonly StudentContext _context;

        public SqlStudentRepo(StudentContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {
           if(student == null){
               throw new ArgumentNullException(nameof(student));
           }
            _context.Add<Student>(student);
            
        }

        public void DeleteStudent(Student student)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault<Student>(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateStudent(Student student)
        {
            
        }
    }
}