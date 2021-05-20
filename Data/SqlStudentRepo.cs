using System.Collections.Generic;
using StudentApi.Models;

namespace StudentApi.Data
{
    public class SqlStudentRepo : IStudentRepo
    {
        public IEnumerable<Student> GetAllStudents()
        {
            throw new System.NotImplementedException();
        }

        public Student GetStudentById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}