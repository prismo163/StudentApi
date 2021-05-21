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
            throw new System.NotImplementedException();
        }
    }
}