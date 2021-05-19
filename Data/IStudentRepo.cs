using System.Collections.Generic;
using StudentApi.Models;

namespace StudentApi.Data
{
    public interface IStudentRepo
    {
        public bool SaveChanges();
        public IEnumerable<Student> GetAllStudents();
        
        public Student GetStudentById(int id);
    }
}